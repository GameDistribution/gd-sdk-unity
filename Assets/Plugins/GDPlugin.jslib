var functions = {
	InitApi: function(gameKey, userId) {
	 window["GD_OPTIONS"] = {
        "debug": false, // Enable debugging console. This will set a value in local storage as well, remove this value if you don't want debugging at all. You can also call it by running gdsdk.openConsole() within your browser console.
        "gameId": "49258a0e497c42b5b5d87887f24d27a6", // Your gameId which is unique for each one of your games; can be found at your Gamedistribution.com account.
        "userId": "ABD36C6C-E74B-4BA7-BE87-0AB01F98D30D-s1", // Your userId which can be found at your Gamedistribution.com account.
        "advertisementSettings": {
            "debug": false, // Enable IMA SDK debugging.
            "prefix": "gd-", // Set your own prefix in case you get id conflicts.
            "autoplay": false, // Enable auto start of pre-roll advertisement. Will be disabled when auto play is not supported.
            "responsive": true, // Enable advertisement responsiveness, otherwise given width and height will be used.
            "width": 640, // Width of the advertisement if the ad is not set to be responsive.
            "height": 360, // Height of the advertisement if the ad is not set to be responsive.
            "locale": "en", // Locale used in IMA SDK, this will localise the "Skip ad after x seconds" phrases.
            "container": "", // Container id for custom ad placement.
        },
        "onEvent": function(event) {
            switch (event.name) {
                case "SDK_GAME_START":
                    SendMessage('GameDistribution', 'ResumeGame');
                    break;
                case "SDK_GAME_PAUSE":
                    SendMessage('GameDistribution', 'PauseGame');
                    break;
                case "SDK_READY":
                    // ...
                    break;
                case "SDK_ERROR":
                    // ...
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
	
