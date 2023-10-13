namespace Frontend.Models.RequestLoaders; 

public interface IRequestLoader {
    HttpClient HttpClient { get; set; }
    LoadRequest LoadRequest { get; set; }
}