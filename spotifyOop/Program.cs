using spotifyOop;

User? active_user = null;
SpotifyFacade facade = new SpotifyFacade();
MainState state = MainState.LOGIN;
SubState subState = SubState.NONE;
bool active = true;

while (active)
{
    if (state == MainState.LOGIN)
    {
        string? username = TakeChoice("enter your name:");

        if (username == "" || username == null)
        {
            Console.WriteLine("\nplease enter a username");
            continue;
        }

        User? user = facade.GetUser(username);

        if (user == null)
        {
            Console.WriteLine($"\n{username} is not a user\n");
            continue;
        }

        active_user = user;
        state = MainState.MAIN_MENU;
    }

    if (state == MainState.MAIN_MENU)
    {
        Console.Clear();
        Console.WriteLine($"welcome {active_user.Name}");

        string? chiose = TakeChoice("1. See all albums\n2. See all numbers\n3. See all users\n4. See all friends\n5. See your playlists\n6. Exit\n7. log out");
        int numchoise = ValidateChoise(chiose);

        if (numchoise == 0)
        {
            continue;
        }

        switch (numchoise)
        {
            case 1:
                state = MainState.ALBUMS;
                break;

            case 2:
                state = MainState.NUMBERS;
                break;

            case 3:
                state = MainState.USERS;
                break;

            case 4:
                state = MainState.FRIENDS;
                break;

            case 5:
                state = MainState.PLAYLISTS;
                break;

            case 6:
                active = false;
                continue;

            case 7:
                state = MainState.LOGIN;
                continue;

            default:
                Console.WriteLine("enter valid choise");
                break;
        }
    }

    if (state == MainState.ALBUMS)
    {
        Console.Clear();

        int i = 1;

        foreach (Album album in facade.allAlbums)
        {
            Console.WriteLine($"\n{i}. ");
            album.ShowAlbum();
            i++;
        }

        Console.WriteLine($"\n{i}. Back");

        string? choise = TakeChoice("select album");
        int numchoise = ValidateChoise(choise);

        if (numchoise == 0)
        {
            continue;
        }
        else if (numchoise == i)
        {
            state = MainState.MAIN_MENU;
            continue;
        }

        Album? seleceted_album = facade.GetAlbum(numchoise - 1);

        if (seleceted_album == null)
        {
            Console.WriteLine("invallid choise");
            continue;
        }

        subState = SubState.ALBUM_SLECTED;

        while (subState == SubState.ALBUM_SLECTED)
        {
            Console.Clear();
            choise = TakeChoice("1. See numbers\n2. Play album\n3. Add to playlist\n4. Back");
            numchoise = ValidateChoise(choise);

            List<string> playlists = [];

            switch (numchoise)
            {
                case 1:
                    Console.Clear();
                    List<string> numbers = facade.ShowAllNumbers(seleceted_album);
                    int index = 1;

                    foreach (string number in numbers)
                    {
                        Console.WriteLine($"{index}. {number}");
                        index++;
                    }

                    Console.WriteLine($"{index}. Back");

                    string? choice = TakeChoice("");
                    numchoise = ValidateChoise(choise);

                    if (numchoise == 0)
                    {
                        continue;
                    }
                    else if (numchoise == index)
                    {
                        state = MainState.MAIN_MENU;
                        continue;
                    }

                    Number? selectedNumber = facade.GetNumber(seleceted_album, numchoise - 1);

                    if (selectedNumber == null)
                    {
                        Console.WriteLine("not a valid choise");
                        continue;
                    }

                    Console.Clear();

                    choise = TakeChoice("1. Play\n2. Add to playlist");
                    numchoise = ValidateChoise(choise);

                    if (numchoise == 0)
                    {
                        continue;
                    }
                    if (numchoise == 1)
                    {
                        facade.PlayPlayable(selectedNumber);
                        TakeChoice("press enter");
                    }
                    else if (numchoise == 2)
                    {
                        playlists = facade.ShowAllPlaylists(active_user, ["New playlist"]);
                        int album = ShowAndSelectPlaylists(playlists);

                        if (album == 0)
                        {
                            continue;
                        }

                        if (album == playlists.Count)
                        {
                            string? name = TakeChoice("enter name");

                            if (name == null || name == "")
                            {
                                Console.WriteLine("enter a valid name");
                                continue;
                            }

                            facade.CreatePlaylist(active_user, name, selectedNumber);
                        }
                        else if (album < playlists.Count)
                        {
                            Playlist? playlist = facade.GetPlaylist(active_user, playlists[numchoise - 1]);

                            if (playlist == null)
                            {
                                Console.WriteLine("not a valid choise");
                                continue;
                            }

                            facade.AddNumber(playlist, selectedNumber);
                        }
                    }
                    else
                    {
                        Console.WriteLine("not a valid choise");
                        continue;
                    }
                    break;

                case 2:
                    facade.PlayPlayable(seleceted_album);
                    TakeChoice("press enter");
                    break;

                case 3:
                    Console.Clear();

                    playlists = facade.ShowAllPlaylists(active_user, ["New playlist"]);
                    numchoise = ShowAndSelectPlaylists(playlists);

                    if (numchoise == 0)
                    {
                        continue;
                    }
                    if (numchoise == playlists.Count)
                    {
                        string? name = TakeChoice("enter valid name");

                        if (name == null || name == "")
                        {
                            Console.WriteLine("enter a name");
                            continue;
                        }

                        facade.CreatePlaylist(active_user, name, seleceted_album);
                    }
                    else if (numchoise < playlists.Count)
                    {
                        Playlist? playlist = facade.GetPlaylist(active_user, playlists[numchoise - 1]);

                        if (playlist == null)
                        {
                            continue;
                        }

                        facade.AddNumbers(playlist, seleceted_album.Numbers);
                    }
                    else
                    {
                        Console.WriteLine("not a valid choice");
                        continue;
                    }

                    break;

                case 4:
                    subState = SubState.NONE;
                    continue;

                default:
                    Console.WriteLine("enter valid choise");
                    break;
            }
        }
    }

    if (state == MainState.PLAYLISTS)
    {
        Console.Clear();

        List<string> playlists = facade.ShowAllPlaylists(active_user, ["Add playlist", "Back"]);

        int numchoise = ShowAndSelectPlaylists(playlists);

        if (numchoise == 0)
        {
            continue;
        }
        if (numchoise == playlists.Count - 1)
        {
            Console.Clear();
            string? name = TakeChoice("Enter playlist name");

            if (name == "" || name == null)
            {
                Console.WriteLine("Enter a valid name");
                continue;
            }
            Number? number = null;

            facade.CreatePlaylist(active_user, name, number);
        }
        else if (numchoise == playlists.Count)
        {
            state = MainState.MAIN_MENU;
            continue;
        }
        else
        {
            Console.Clear();

            Playlist? selectedPlaylist = facade.GetPlaylist(active_user, playlists[numchoise - 1]);

            if (selectedPlaylist == null)
            {
                Console.WriteLine("not a valid choise");
                continue;
            }

            subState = SubState.PLAYLIST_SELECTED;

            while (subState == SubState.PLAYLIST_SELECTED)
            {
                string? choise = TakeChoice("1. Delete\n2. See numbers\n3. Play playlist\n4. Back");
                numchoise = ValidateChoise(choise);

                if (numchoise == 0)
                {
                    continue;
                }

                switch (numchoise)
                {
                    case 1:
                        facade.DeletePlaylist(active_user, selectedPlaylist);
                        break;

                    case 2:
                        Numbers();
                        break;

                    case 3:
                        facade.PlayPlayable(selectedPlaylist);
                        TakeChoice("press enter");

                        break;

                    case 4:
                        subState = SubState.NONE;
                        continue;

                    default:
                        Console.WriteLine("enter valid number");
                        break;
                }
            }
        }
    }

    if (state == MainState.NUMBERS)
    {
        Numbers();
    }

    if (state == MainState.USERS)
    {
        Console.Clear();

        List<User> users = facade.GetUsers(active_user);

        int index = 1;

        foreach (User user in users)
        {
            Console.WriteLine($"{index}. {user.Name}");
            index++;
        }

        Console.WriteLine($"{index}. Back");

        string? choice = TakeChoice("select user");
        int numchoice = ValidateChoise(choice);

        if (numchoice == 0)
        {
            continue;
        }
        else if (numchoice == index)
        {
            state = MainState.MAIN_MENU;
            continue;
        }

        if (numchoice <= users.Count)
        {
            User selUser = users[numchoice - 1];

            choice = TakeChoice("1. Add as fiend\n2. Back");
            numchoice = ValidateChoise(choice);

            if (numchoice == 0)
            {
                continue;
            }

            if (numchoice == 1)
            {
                facade.AddFriend(active_user, selUser);
                continue;
            }
            else if (numchoice == 2)
            {
                continue;
            }
            else
            {
                Console.WriteLine("enter valid choice");
                continue;
            }
        }
    }

    if (state == MainState.FRIENDS)
    {
        Console.Clear();

        List<User> friends = facade.GetFriends(active_user);

        int index = 1;

        foreach (User user in friends)
        {
            Console.WriteLine($"{index}. {user.Name}");
            index++;
        }

        Console.WriteLine($"{index}. Back");

        string? choice = TakeChoice("Select friend");
        int numchoice = ValidateChoise(choice);

        if (numchoice == 0)
        {
            continue;
        }
        else if (numchoice == index)
        {
            state = MainState.MAIN_MENU;
            continue;
        }

        if (numchoice <= friends.Count)
        {
            Console.Clear();

            User selFriend = friends[numchoice - 1];

            subState = SubState.FRIEND_SELECTED;

            while (subState == SubState.FRIEND_SELECTED)
            {
                Console.Clear();

                choice = TakeChoice("1. Remove friend\n2. Playlists\n3. Back");
                numchoice = ValidateChoise(choice);

                if (numchoice == 0)
                {
                    continue;
                }
                else if (numchoice == 3)
                {
                    subState = SubState.NONE;
                    continue;
                }

                if (numchoice == 1)
                {
                    facade.RemoveFriend(active_user, selFriend);
                }
                else if (numchoice == 2)
                {
                    Console.Clear();

                    List<Playlist> friendPlayists = facade.GetPlaylists(selFriend);

                    index = 1;

                    foreach (Playlist playlist in friendPlayists)
                    {
                        Console.WriteLine($"{index}. {playlist.Name}");
                        index++;
                    }

                    Console.WriteLine($"{index}. Back");

                    choice = TakeChoice("Select playlist");
                    numchoice = ValidateChoise(choice);

                    if (numchoice == 0)
                    {
                        continue;
                    }
                    else if (numchoice == index)
                    {
                        continue;
                    }

                    if (numchoice <= friendPlayists.Count)
                    {
                        Playlist selPlaylist = friendPlayists[numchoice - 1];

                        Console.Clear();

                        choice = TakeChoice("1. take over playlist\n2. see numbers\n3. add to playlist\n4. Play playlist");
                        numchoice = ValidateChoise(choice);

                        if (numchoice == 0)
                        {
                            continue;
                        }

                        switch (numchoice)
                        {
                            case 1:
                                facade.AddPlaylist(selPlaylist, active_user);
                                break;

                            case 2:
                                Numbers();
                                break;

                            case 3:
                                Console.Clear();

                                List<string> playlists = facade.ShowAllPlaylists(active_user, ["New playlist"]);
                                int numchoise = ShowAndSelectPlaylists(playlists);

                                if (numchoise == 0)
                                {
                                    continue;
                                }

                                if (numchoise == playlists.Count)
                                {
                                    string? name = TakeChoice("enter valid name");

                                    if (name == null || name == "")
                                    {
                                        Console.WriteLine("enter a name");
                                        continue;
                                    }

                                    facade.CreatePlaylist(active_user, name, selPlaylist);
                                }
                                else if (numchoise < playlists.Count)
                                {
                                    Playlist? playlist = facade.GetPlaylist(active_user, playlists[numchoise - 1]);

                                    if (playlist == null)
                                    {
                                        continue;
                                    }

                                    facade.AddNumbers(playlist, selPlaylist.Numbers);
                                }
                                else
                                {
                                    Console.WriteLine("not a valid choice");
                                    continue;
                                }
                                break;

                            case 4:
                                facade.PlayPlayable(selPlaylist);
                                TakeChoice("press enter");

                                break;

                            default:
                                Console.WriteLine("enter valid choice");
                                break;
                        }

                    }
                    else
                    {
                        Console.WriteLine("enter valid choice");
                        continue;
                    }

                }
                else
                {
                    Console.WriteLine("invallid choice");
                    continue;
                }
            }

        }
        else
        {
            Console.WriteLine("invallid choise");
            continue;
        }
    }
}

void Numbers()
{
    Console.Clear();

    List<string> numbers = facade.GetAllNumbers(["Back"]);

    int index = 1;

    foreach (string number in numbers)
    {
        Console.WriteLine($"{index}. " + number);
        index++;
    }

    string? choice = TakeChoice("Select number");
    int numchoice = ValidateChoise(choice);

    if (numchoice == 0)
    {
        return;
    }

    if (numchoice == numbers.Count)
    {
        state = MainState.MAIN_MENU;
        return;
    }
    else if (numchoice < numbers.Count)
    {
        Number? number = facade.GetNumber(numbers[numchoice - 1]);

        if (number == null)
        {
            Console.WriteLine("not a valid choice");
            return;
        }

        subState = SubState.NUMBER_SELECTED;

        while (subState == SubState.NUMBER_SELECTED)
        {
            Console.Clear();

            choice = TakeChoice("1. Play\n2. Add to playlist\n3. Back");
            numchoice = ValidateChoise(choice);

            if (numchoice == 0)
            {
                continue;
            }
            else if (numchoice == 3)
            {
                subState = SubState.NONE;
                continue;
            }

            if (numchoice == 1)
            {
                facade.PlayPlayable(number);
                TakeChoice("press enter");
            }
            else if (numchoice == 2)
            {
                Console.Clear();

                List<string> playlists = facade.ShowAllPlaylists(active_user, ["New playlist"]);
                int numchoise = ShowAndSelectPlaylists(playlists);

                if (numchoise == 0)
                {
                    continue;
                }

                if (numchoise == playlists.Count)
                {
                    string? name = TakeChoice("enter valid name");

                    if (name == null || name == "")
                    {
                        Console.WriteLine("enter a name");
                        continue;
                    }

                    facade.CreatePlaylist(active_user, name, number);
                }
                else if (numchoise < playlists.Count)
                {
                    Playlist? playlist = facade.GetPlaylist(active_user, playlists[numchoise - 1]);

                    if (playlist == null)
                    {
                        continue;
                    }

                    facade.AddNumber(playlist, number);
                }
                else
                {
                    Console.WriteLine("not a valid choice");
                    continue;
                }
            }
            else
            {
                Console.WriteLine("not a valid choice");
                continue;
            }
        }
    }
    else
    {
        Console.WriteLine("enter a valid choice");
        return;
    }
}

int ShowAndSelectPlaylists(List<string> playlists)
{
    int index = 1;

    foreach (string playlist in playlists)
    {
        Console.WriteLine($"{index.ToString()}. " + playlist);
        index++;
    }

    Console.WriteLine("\nSelect a option");
    string? choise = Console.ReadLine();
    int numchoise = ValidateChoise(choise);

    return numchoise;
}

int ValidateChoise(string? choise)
{
    int numchoise;

    if (choise == "" || choise == null)
    {
        Console.WriteLine("\nplease enter something");
        return 0;
    }

    try
    {
        numchoise = Int32.Parse(choise);
    }
    catch (Exception e)
    {
        Console.WriteLine("not a number");
        return 0;
    }

    return numchoise;
}

string? TakeChoice(string header)
{
    Console.WriteLine(header);
    return Console.ReadLine();
}

internal enum MainState
{
    LOGIN,
    MAIN_MENU,
    ALBUMS,
    PLAYLISTS,
    NUMBERS,
    USERS,
    FRIENDS
}

internal enum SubState
{
    NONE,
    ALBUM_SLECTED,
    PLAYLIST_SELECTED,
    NUMBER_SELECTED,
    FRIEND_SELECTED
}
