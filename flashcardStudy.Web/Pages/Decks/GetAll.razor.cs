using flascardStudy.Core.Handler;
using flascardStudy.Core.Models;
using flascardStudy.Core.Requests.Deck;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace flashcardStudy.Web.Pages.Decks
{
    public partial class GetAllDecksPage : ComponentBase
    {
        #region Props

        public bool IsBusy = false;
        public List<DeckModel> Decks { get; set; } = [];

        #endregion

        #region Services

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;
        [Inject]
        public IDeckHandler Handler { get; set; } = null!;

        [Inject]
        public IDialogService Dialog { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        #endregion

        #region Overrides

        protected override async Task OnInitializedAsync()
        {
            IsBusy = true;
            try 
            {
                var request = new GetAllDecksRequest();
                var result = await Handler.GetAllAsync(request);
                if (result.IsSuccess)
                    Decks = result.Data ?? [];
            } 
            catch (Exception ex) 
            { 
                Snackbar.Add(ex.Message, Severity.Error);
            } 
            finally { IsBusy = false; }
        }

        #endregion

        #region Delete Deck
        public async Task OnDeleteButtonClickedAsync(int id, string title)
        {
            var result =  await Dialog.ShowMessageBox(
                "ATENÇÃO",
                $"Tem certeza que deseja excluir o Deck {title}?",
                yesText: "Cancelar",
                cancelText: "Excluir");
            if(result == false || result == null)
            {
                await OnDeleteAsync(id, title);
            }

            StateHasChanged();
        }

        public async Task OnDeleteAsync(int id, string title)
        {
            try
            {
                var request = new DeleteDeckRequest { Id = id };
                await Handler.DeleteAsync(request);
                Decks.RemoveAll(d => d.Id == id);
                Snackbar.Add($"Deck {title} removido!", Severity.Info);
            }
            catch (Exception e )
            {
                Snackbar.Add(e.Message, Severity.Error);
            }
        }
        #endregion

        #region DeckDetails
        public void OnDeckButtonClickAsync(int id)
        {
            NavigationManager.NavigateTo($"flashcards/{id}");
        }
        #endregion

        #region Edit Deck

        public void OnEditButtomClickedAsync(int id)
        {
            NavigationManager.NavigateTo($"/decks/edit/{id}");
        }

        #endregion
    }
}
