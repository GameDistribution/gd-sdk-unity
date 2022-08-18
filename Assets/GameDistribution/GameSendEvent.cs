using System;
using System.Collections.Generic;

[Serializable]
public class GameSendEvent
{ 
    public GameSendEventData data;
    public string eventName;
    // public int level;
    // public int score;
}
[Serializable]
public class GameSendEventData 
{
    public int level;
    public int score;
}