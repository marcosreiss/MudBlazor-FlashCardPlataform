using flascardStudy.Core.Handler;
using flascardStudy.Core.Models;
using flascardStudy.Core.Requests.FlashCard;
using flascardStudy.Core.Response;
using flashcardStudy.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace flashcardStudy.Api.Handlers
{
    public class FlashCardHandler(AppDbContext context) : IFlashCardHandler
    {
        public async Task<Response<FlashCardModel?>> CreateAsync(CreateFlashCardRequest request)
        {
            var flashCard = new FlashCardModel 
            {
                Front = request.Front,
                Back = request.Back,
                DeckId = request.DeckId,
            };

            try
            {
                await context.FlashCards.AddAsync(flashCard);
                await context.SaveChangesAsync();

                return new Response<FlashCardModel?>(flashCard, 201, "FlashCardModel criado com sucesso");
            }
            catch (Exception ex) 
            { 
                //serilog, OpenTelemetry
                return new Response<FlashCardModel?>(null, 500, "Não foi possivel criar o FlashCardModel:\n" + ex.Message);
            }
        }

        public async Task<Response<FlashCardModel?>> DeleteAsync(DeleteFlashCardRequest request)
        {
            try
            {
                var flashCard = await context
                    .FlashCards
                    .FirstOrDefaultAsync(x => x.Id == request.Id);
                if (flashCard == null)
                {
                    return new Response<FlashCardModel?>(null, 404, "FlashCardModel Não encontrado");
                }

                context.FlashCards.Remove(flashCard);
                await context.SaveChangesAsync();

                return new Response<FlashCardModel?>(flashCard, 200, "Deletado com sucesso com sucesso!");
            }
            catch (Exception ex)
            {
                return new Response<FlashCardModel?>(null, 500, "Erro ao Deletar flash card:\n" + ex.Message);
            }
        }

        public async Task<PagedResponse<List<FlashCardModel>?>> GetAllAsync(GetAllFlashCardsRequest request)
        {
            var query = context.FlashCards
                .AsNoTracking()
                .OrderBy(x => x.Id);

            try
            {
                //select
                var flashCards = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                //count
                var count = await query.CountAsync();

                return new PagedResponse<List<FlashCardModel>?>(
                    flashCards,
                    count,
                    request.PageNumber,
                    request.PageSize);
            } catch (Exception ex)
            {
                var response =  new PagedResponse<List<FlashCardModel>?>(null, 0, 0, 0);
                response.Message = "Erro ao recuperar Flash Cards" + ex.Message;
                response._statusCode = 500;
                return response;
            }
        }

        public async Task<Response<FlashCardModel?>> GetByIdAsync(GetFlashCardByIdRequest request)
        {
            try
            {
                var flashCard = await context
                    .FlashCards
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == request.Id);
                if (flashCard == null)
                {
                    return new Response<FlashCardModel?>(null, 404, "FlashCardModel Não encontrado");
                }

                return new Response<FlashCardModel?>(flashCard, 200, "sucesso!");
            }
            catch (Exception ex)
            {
                return new Response<FlashCardModel?>(null, 500, "Erro ao recuperar flash card:\n" + ex.Message);
            }
        }

        public async Task<Response<FlashCardModel?>> UpdateAsync(UpdateFlashCardRequest request)
        {
            try
            {
                var flashCard = await context
                    .FlashCards
                    .FirstOrDefaultAsync(x=> x.Id == request.Id);
                if (flashCard == null)
                {
                    return new Response<FlashCardModel?>(null, 404, "FlashCardModel Não encontrado");
                }

                flashCard.Front = request.Front;
                flashCard.Back = request.Back;
                context.FlashCards.Update(flashCard);
                await context.SaveChangesAsync();

                return new Response<FlashCardModel?>(flashCard, 201, "Atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return new Response<FlashCardModel?>(null, 500, "Erro ao Atualizar flash card:\n" + ex.Message);
            }
        }
    }
}
