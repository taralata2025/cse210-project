// Video.cs
using System;
using System.Collections.Generic; // Required for List<Comment>

public class Video
{
    private string _title;
    private string _author;
    private int _lengthInSeconds;
    private List<Comment> _comments; // List to store Comment objects

    // Constructor to initialize a new video
    public Video(string title, string author, int lengthInSeconds)
    {
        _title = title;
        _author = author;
        _lengthInSeconds = lengthInSeconds;
        _comments = new List<Comment>(); // Initialize the list of comments
    }

    // Method to add a comment to this video
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Method to return the number of comments for this video
    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    // Public methods to get video details (for display in Program.cs)
    public string GetTitle()
    {
        return _title;
    }

    public string GetAuthor()
    {
        return _author;
    }

    public int GetLengthInSeconds()
    {
        return _lengthInSeconds;
    }

    // Method to get the list of comments (for iteration in Program.cs)
    public List<Comment> GetComments()
    {
        return _comments;
    }
}