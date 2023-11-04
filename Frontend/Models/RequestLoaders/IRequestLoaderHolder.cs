namespace Frontend.Models.RequestLoaders; 

public interface IRequestLoaderHolder {
    IRequestLoader RequestLoader { get; }
}