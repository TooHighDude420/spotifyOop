using spotifyOop;

User mainUser = new("main");
User friendTest = new("friend");

Number testNumber = new Number("bad", "pop", "michael jackson");

SpotifyFacade facade = new SpotifyFacade();

//testing playlist features
facade.createPlaylist(mainUser, "testplay", null);
Playlist? testlist = facade.getPlaylist(mainUser, "testplay");

if (testlist != null) 
{
    facade.addNumber(testlist, testNumber);
}

//testing friend features
mainUser.AddFriend(friendTest);
friendTest.AddFriend(mainUser);

facade.showUserFriends(mainUser);
facade.showUserFriends(friendTest);