using flascardStudy.Core.Handler;
using flascardStudy.Core.Models;
using flascardStudy.Core.Requests.Deck;
using flascardStudy.Core.Response;
using flashcardStudy.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace flashcardStudy.Api.Handlers
{
    public class DeckHandler(AppDbContext context) : IDeckHandler
    {
        public async Task<Response<DeckModel?>> CreateAsync(CreateDeckRequest request)
        {
            var deck = new DeckModel
            {
                Title = request.Title,
            };

            try
            {
                await context.Decks.AddAsync(deck);
                await context.SaveChangesAsync();

                return new Response<DeckModel?>(deck, 201, "Deck criado com sucesso");
            }
            catch (Exception ex)
            {
                //serilog, OpenTelemetry
                return new Response<DeckModel?>(null, 500, "Não foi possivel criar o DeckModel:\n" + ex.Message);
            }
        }

        public async Task<Response<DeckModel?>> DeleteAsync(DeleteDeckRequest request)
        {
            try
            {
                var deck = await context
                    .Decks
                    .FirstOrDefaultAsync(x => x.Id == request.Id);
                if (deck == null)
                {
                    return new Response<DeckModel?>(null, 404, "Deck não encontrado");
                }

                context.Decks.Remove(deck);
                await context.SaveChangesAsync();

                return new Response<DeckModel?>(deck, 201, "Deck Apagado com sucesso!");
            } 
            catch (Exception ex)
            {
                return new Response<DeckModel?>(null, 500, "Erro ao apagar Deck:\n" + ex.Message);
            }
        }

        public async Task<PagedResponse<List<DeckModel>?>> GetAllAsync(GetAllDecksRequest request)
        {
            var query = context
                .Decks
                .Include(x => x.Cards)
                .AsNoTracking()
                .OrderBy(x => x.Id);
            try
            {
                var decks = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();

                return new PagedResponse<List<DeckModel>?>(
                    decks, 
                    count, 
                    request.PageNumber, 
                    request.PageSize);
            }
            catch (Exception ex)
            {
                var response = new PagedResponse<List<DeckModel>?>(null, 0, 0, 0);
                response.Message = "Erro ao recuperar Decks" + ex.Message;
                response._statusCode = 500;
                return response;
            }
        }

        public async Task<Response<DeckModel?>> GetByIdAsync(GetDeckByIdRequest request)
        {
            try
            {
                var deck = await context
                    .Decks
                    .AsNoTracking()
                    .Include(x => x.Cards)
                    .FirstOrDefaultAsync(x => x.Id == request.Id);
                if (deck == null)
                {
                    return new Response<DeckModel?>(null, 404, "Deck não encontrado");
                }

                return new Response<DeckModel?>(deck, 200, "Sucesso ao recuperar Deck!");
            }
            catch (Exception ex)
            {
                return new Response<DeckModel?>(null, 500, "Erro ao recuperar Deck:\n" + ex.Message);
            }
        }

        public async Task<Response<DeckModel?>> UpdateAsync(UpdateDeckRequest request)
        {
            try
            {
                var deck = await context
                    .Decks
                    .FirstOrDefaultAsync(x => x.Id == request.Id);
                if (deck == null)
                {
                    return new Response<DeckModel?>(null, 404, "Deck não encontrado");
                }

                deck.Title = request.Title;
                context.Decks.Update(deck);
                await context.SaveChangesAsync();

                return new Response<DeckModel?>(deck, 200, "Deck Atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return new Response<DeckModel?>(null, 500, "Erro ao atualizar Deck:\n" + ex.Message);
            }
        }
    }
}
