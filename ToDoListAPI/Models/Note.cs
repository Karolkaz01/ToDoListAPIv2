﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ToDoListAPI.Models;

public class Note
{
    public int Id { get; set; }

    public string NoteValue { get; set; }

    public string Title { get; set; }

    public DateTime CreateDate { get; set; }
}