// Video.cs
using System;
using System.Collections.Generic;

namespace YouTubeTracker
{
    public class Video
    {
        public string _title { get; set; }
        public string _author { get; set; }
        public int _lengthInSeconds { get; set; }
        private List<Comment> _comments { get; set; }

        public Video(string title, string author, int length)
        {
            _title = title;
            _author = author;
            _lengthInSeconds = length;
            _comments = new List<Comment>();
        }

        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }

        public int GetNumberOfComments()
        {
            return _comments.Count;
        }

        public List<Comment> GetAllComments()
        {
            return new List<Comment>(_comments);
        }
    }
}