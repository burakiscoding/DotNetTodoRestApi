﻿using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetTodoRestApi.Models
{
    [Table("Comments")]
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreateadOn { get; set; }
        public int? TodoId { get; set; }
        //Navigation
        public Todo? Todo { get; set; }
    }
}
