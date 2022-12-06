using System;
using System.Collections.Generic;

[Serializable]
public class EventData<T>
{
    public T data;
    public string eventName;
}
// This is for example You ca add or replace this
[Serializable]
public class GameEventData
{
    public int level;
    public int score;
}
// This is for example You ca add or replace this
[Serializable]
public class MileStoneData
{
    public bool isAuthorized;
    public string milestoneDescription;
}