namespace Frontend.Models.RequestLoaders;

public interface IRequestLoader {
    HttpClient HttpClient { get; set; }
    RequestLoadController RequestLoadController { get; set; }
}