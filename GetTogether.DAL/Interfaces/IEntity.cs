﻿namespace GetTogether.DAL.Interfaces;

public interface IEntity<T>
{
    public T Id { get; set; }
}
