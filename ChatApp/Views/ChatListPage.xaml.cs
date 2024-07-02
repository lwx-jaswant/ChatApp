namespace ChatApp;

public partial class ChatListPage : ContentPage
{
    public ChatListPage(ChatListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel; 
	}    
}