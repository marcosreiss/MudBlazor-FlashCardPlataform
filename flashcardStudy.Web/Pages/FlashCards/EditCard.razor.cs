using flascardStudy.Core.Handler;
using flascardStudy.Core.Requests.Deck;
using flascardStudy.Core.Requests.FlashCard;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace flashcardStudy.Web.Pages.FlashCards
{
    public partial class EditCardPage : ComponentBase
    {
        #region Props

        public bool IsBusy { get; set; } = false;
        public UpdateFlashCardRequest InputModel { get; set; } = new();
        [Parameter] public int Id { get; set; }

        #endregion

        #region Services

        [Inject]
        public IFlashCardHandler Handler { get; set; } = null!;
        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!; //para navegar entre as páginas
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        #endregion

        #region Methods

        public async Task OnValidSubmitAsync()
        {
            IsBusy = true;
            try
            {
                var result = await Handler.UpdateAsync(InputModel);
                if (result.IsSuccess)
                {
                    Snackbar.Add(result.Message, Severity.Info);
                    var deckId = result.Data?.DeckId;
                    NavigationManager.NavigateTo($"/flashcards/{deckId}");
                }
                else Snackbar.Add(result.Message, Severity.Error);
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
            finally { IsBusy = false; }
        }

        protected override async Task OnInitializedAsync()
        {
            IsBusy = true;
            try
            {
                var request = new GetFlashCardByIdRequest { Id = this.Id };
                var result = await Handler.GetByIdAsync(request);
                if (result.IsSuccess)
                {
                    InputModel.Id = this.Id;
                    InputModel.Front = result.Data?.Front ?? string.Empty;
                    InputModel.Back = result.Data?.Back ?? string.Empty;
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
            finally { IsBusy = false; }
        }

        #endregion
    }
}
