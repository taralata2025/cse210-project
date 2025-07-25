// Comment.cs
using System;

public class Comment
{
    private string _commenterName;
    private string _commentText;

    // Constructor to initialize a new comment
    public Comment(string commenterName, string commentText)
    {
        _commenterName = commenterName;
        _commentText = commentText;
    }

    // Public methods to get the comment's information
    public string GetCommenterName()
    {
        return _commenterName;
    }

    public string GetCommentText()
    {
        return _commentText;
    }
}