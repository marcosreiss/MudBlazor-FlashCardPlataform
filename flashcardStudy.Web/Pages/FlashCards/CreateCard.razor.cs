using flascardStudy.Core.Handler;
using flascardStudy.Core.Models;
using flascardStudy.Core.Requests.Deck;
using flascardStudy.Core.Requests.FlashCard;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace flashcardStudy.Web.Pages.FlashCards
{
    public partial class CreateFlashCardPage : ComponentBase
    {
        #region Props

        public bool IsBusy = false;
        public CreateFlashCardRequest InputModel { get; set; } = new();
        public List<DeckModel> Decks { get; set; } = [];

        #endregion

        #region Services

        [Inject] public IFlashCardHandler FlashCardHandler { get; set; } = null!;
        [Inject] public IDeckHandler DeckHandler { get; set; } = null!;
        [Inject] public ISnackbar snackbar { get; set; } = null!;
        [Inject] public NavigationManager navigationManager { get; set; } = null!;

        #endregion

        #region Methods

        public async Task OnValidSubmitAsync()
        {
            IsBusy = true;
            try
            {
                var response = await FlashCardHandler.CreateAsync(InputModel);
                if (response.IsSuccess)
                {
                    snackbar.Add(response.Message, Severity.Success);
                    navigationManager.NavigateTo("/");
                }
                else
                {
                    snackbar.Add(response.Message, Severity.Error);
                }
            }
            catch (Exception ex)
            {
                snackbar.Add(ex.Message, Severity.Error);

            }
            finally { IsBusy = false; }
        }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var request = new GetAllDecksRequest { PageSize = 100};
                var response = await DeckHandler.GetAllAsync(request);
                if (response.IsSuccess)
                {
                    Decks = response.Data ?? [];
                }
                else
                {
                    snackbar.Add("Não foi possível recuperar Decks", Severity.Error);
                }
            }
            catch(Exception ex) 
            {
                snackbar.Add("Não foi possível recuperar Decks", Severity.Error);
            }
        }

        #endregion
    }
}
