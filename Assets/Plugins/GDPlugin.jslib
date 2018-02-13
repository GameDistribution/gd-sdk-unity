var functions = {
	InitApi: function(gameKey, userId) {
	
	gameKey = Pointer_stringify(gameKey);
	userId = Pointer_stringify(userId);
	
	 window["GD_OPTIONS"] = {
        "debug": false, // Enable debugging console. This will set a value in local storage as well, remove this value if you don't want debugging at all. You can also call it by running gdsdk.openConsole() within your browser console.
        "gameId": gameKey, // Your gameId which is unique for each one of your games; can be found at your Gamedistribution.com account.
        "userId": userId, // Your userId which can be found at your Gamedistribution.com account.
        "onEvent": function(event) {
            switch (event.name) {
                case "SDK_GAME_START":
                    SendMessage('GameDistribution', 'ResumeGame');
                    break;
                case "SDK_GAME_PAUSE":
                    SendMessage('GameDistribution', 'PauseGame');
                    break;
				case "SDK_ERROR":					
					break;
            }
        },
    };
	(function(d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s);
    js.id = id;
    js.src = '//html5.api.gamedistribution.com/main.min.js';
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'gamedistribution-jssdk'));
	},
		 
	ShowBanner: function (gameKey,userID)
	{
	  if (typeof gdsdk !== "undefined")
	  {	  
		gdsdk.showBanner(); 
	  }
	},
 };
 
mergeInto(LibraryManager.library, functions);
	
