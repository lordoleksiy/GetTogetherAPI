﻿using GetTogether.DAL.Interfaces;

namespace GetTogether.DAL.Entities;

public class Message: IEntity<int>
{
    public int Id { get; set; }
    public string text { get; set; }
    public int ChatId { get; set; }
    public ChatGroup ChatGroup { get; set; }
    public int AuthorId { get; set; }
    public UserProfile Author { get; set; }
    public int? RepliedPersonId { get; set; }
    public UserProfile? RepliedPerson { get; set; }
}
