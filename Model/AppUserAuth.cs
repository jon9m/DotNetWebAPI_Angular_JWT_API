namespace PtcApi.Model
{

  public class AppUserAuth
  {
      public AppUserAuth() : base()
      {
          UserName = "Not Authorized";
          BearerToken = string.Empty;
      }

    public string UserName {get; set;} 
    public string BearerToken {get; set;}
    public bool IsAuthenticated {get; set;}
    public bool CanAccessProducts {get; set;}
    public bool CanAddProduct {get; set;}
    public bool CanSaveProduct {get; set;}
    public bool CanAccessCategories {get; set;}
    public bool CanAddCatagory {get; set;}
  }
}