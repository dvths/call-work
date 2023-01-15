using CallWork.Api.ServiceErrors;
using CallWork.Contracts.CallWork;

using ErrorOr;

namespace CallWork.Api.Models;

public class CallWorkModel
{
    public const int MinTitleLength = 3;
    public const int MaxTitleLength = 100;
    public const int MinDescriptionLength = 50;
    public const int MaxDescriptionLength = 300;

    public Guid Id { get; }
    public string Title { get; }
    public string Description { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public DateTime LastModifiedDateTime { get; }
    public List<string> Subjects { get; }
    public List<string> Technologies { get; }

    private CallWorkModel(Guid id, string title, string description, DateTime startDateTime, DateTime endDateTime, DateTime lastModifiedDateTime, List<string> subjects, List<string> technologies)
    {
        Id = id;
        Title = title;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        LastModifiedDateTime = lastModifiedDateTime;
        Subjects = subjects;
        Technologies = technologies;
    }

    public static ErrorOr<CallWorkModel> Create(
        string title,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        List<string> subjects,
        List<string> technologies,
        Guid? id = null)
    {
        List<Error> errors = new();

        if (title.Length is < MinTitleLength or > MaxTitleLength)
        {
            errors.Add(Errors.CallWork.InvalidTitle);
        }

        if (description.Length is < MinDescriptionLength or > MaxDescriptionLength)
        {
            errors.Add(Errors.CallWork.InvalidDescription);
        }

        if (errors.Count > 0)
        {
            return errors;
        }

        return new CallWorkModel(
            id ?? Guid.NewGuid(),
            title,
            description,
            startDateTime,
            endDateTime,
            DateTime.UtcNow,
            subjects,
            technologies
        );
    }

    public static ErrorOr<CallWorkModel> From(CreateCallWorkRequest request)
    {
        return Create(
            request.Title,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            request.Subjects,
            request.Technologies
        );
    }
    public static ErrorOr<CallWorkModel> From(Guid id, UpsertCallWorkRequest request)
    {
        return Create(
            request.Title,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            request.Subjects,
            request.Technologies,
            id);
    }
}