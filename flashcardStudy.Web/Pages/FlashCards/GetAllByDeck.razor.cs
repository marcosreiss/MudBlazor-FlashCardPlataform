using flascardStudy.Core.Handler;
using flascardStudy.Core.Models;
using flascardStudy.Core.Requests.Deck;
using flascardStudy.Core.Requests.FlashCard;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace flashcardStudy.Web.Pages.FlashCards
{
    public partial class GetAllFlashCardsByDeckPage : ComponentBase
    {
        #region Props

        public bool IsBusy = false;
        public List<FlashCardModel> FlashCards { get; set; } = [];

        [Parameter]
        public int deckId { get; set; }

        public string deckName { get; set; } = string.Empty;

        public int position = 0;

        #endregion

        #region Services

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;
        [Inject]
        public IDeckHandler DeckHandler { get; set; } = null!;
        [Inject]
        public IFlashCardHandler FlashCardHandler { get; set; } = null!;
        [Inject]
        public IDialogService Dialog { get; set; } = null!;
        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        #endregion

        #region Override

        protected override async Task OnInitializedAsync()
        {
            IsBusy = true;
            try
            {
                var request = new GetDeckByIdRequest() { Id = deckId };
                var result = await DeckHandler.GetByIdAsync(request);
                if (result.IsSuccess)
                {
                    FlashCards = result.Data?.Cards ?? [];
                    deckName = result.Data?.Title ?? string.Empty;
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
            finally { IsBusy = false; }
        }

        #endregion

        #region PassButtons

        public void NextCard()
        {
            if(position < FlashCards.Count - 1)
            {
                position++;
            }
            else
            {
                Snackbar.Add("Último Card", Severity.Info);
            }
        }

        public void PreviusCard()
        {
            if (position > 0)
            {
                position--;
            }
            else
            {
                Snackbar.Add("Primeiro Card", Severity.Info);
            }
        }

        #endregion

        #region EditButton

        public void OnEditButtonClicked()
        {
            if (!IsBusy)
            {
                var editId = FlashCards[position].Id;
                NavigationManager.NavigateTo($"/flashcards/edit/{editId}");
            }
        }

        #endregion

        #region DeleteButton
        public async Task OnDeleteButtonClickedAsync(int id)
        {
            var result = await Dialog.ShowMessageBox(
                "ATENÇÃO",
                $"Tem certeza que deseja excluir o Card?",
                yesText: "Cancelar",
                cancelText: "Excluir");
            if (result == false || result == null)
            {
                await OnDeleteAsync(id);
            }

            StateHasChanged();
        }

        public async Task OnDeleteAsync(int id)
        {
            try
            {
                var request = new DeleteFlashCardRequest { Id = id };
                await FlashCardHandler.DeleteAsync(request);
                FlashCards.RemoveAll(d => d.Id == id);
                Snackbar.Add("Card removido!", Severity.Info);
            }
            catch (Exception e)
            {
                Snackbar.Add(e.Message, Severity.Error);
            }
        }
        #endregion

    }
}
