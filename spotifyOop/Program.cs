using spotifyOop;

User mainUser = new("main");
User friendTest = new("friend");

Number testNumber = new Number();



SpotifyFacade facade = new SpotifyFacade();

//testing playlist features
facade.createPlaylist(mainUser, "testplay", null);
Playlist? testlist = facade.getPlaylist(mainUser, "testplay");

if (testlist != null) 
{
    facade.addNumber(mainUser, testlist, testNumber);
}

//testing friend features
mainUser.AddFriend(friendTest);
facade.showUserFriends(mainUser);