using spotifyOop;

User mainUser = new("main");
User friendTest = new("friend");

//Hardcoded numbers.
Number Another_part_of_me = new Number("Another part of me", "Pop", "Michael Jackson");
Number Bad = new Number("Bad", "Pop", "Michael Jackson");
Number Dirty_diana = new Number("Dirty Diana", "Pop", "Michael Jackson");
Number Just_good_friends = new Number("Just good friends", "Pop", "Michael Jackson");
Number Leave_me_alone = new Number("Leave me alone", "Pop", "Michael Jackson");
Number Liberian_girl = new Number("Liberain girl", "Pop", "Michael Jackson");
Number Man_in_the_mirror = new Number("Man in the mirror", "Pop", "Michael Jackson");
Number Smooth_criminal = new Number("Smooth Criminal", "Pop", "Michael Jackson");
Number Speed_demon = new Number("Speed Demon", "Pop", "Michael Jackson");
Number The_way_you_make_me_feel = new Number("The way you make me feel", "Pop", "Michael Jackson");
Number I_just_cant_stop_loving_u = new Number("I just can't stop loving u", "Pop", "Michael Jackson");

List<Number> bad = [
    Another_part_of_me,
    Bad,
    Dirty_diana,
    Just_good_friends, 
    Leave_me_alone,
    Liberian_girl, 
    Man_in_the_mirror,
    Smooth_criminal,
    Speed_demon,
    The_way_you_make_me_feel,
    I_just_cant_stop_loving_u,
    ];

Album mj_bad = new Album("bad", "Pop", bad);


SpotifyFacade facade = new SpotifyFacade();

//testing playlist features
facade.createPlaylist(mainUser, "testplay", null);
Playlist? testlist = facade.getPlaylist(mainUser, "testplay");

if (testlist != null) 
{
    facade.addNumber(mainUser, testlist, Bad);
}

//testing friend features
mainUser.AddFriend(friendTest);
facade.showUserFriends(mainUser);

