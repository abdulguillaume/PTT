using PersonalProjectPTT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalProjectPTT.Interfaces
{
    public interface ICommentService
    {
        List<Comment> AllComments();
        List<Comment> AllComments(int id);
        void AddComment(Comment comment);
        void DeleteComment(int id);
        Comment GetComment(int id);
        void UpdateComment(Comment comment);
        void AddComment(int taskId, Comment comment);      
    }
}
