using BlueRibbonsReview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BlueRibbonsReview.ViewModels
{
    public class AdminViewModel
    {
        /*public ApplicationUser ApplicationUser { get; set; }
        public Campaign Campaign { get; set; }*/
        string firstName;
        string lastName;
        string email;
        DateTime joinDate;

        int CampaignCount;


        public AdminViewModel(ApplicationUser appUser)
        {
            firstName = appUser.FirstName;
            lastName = appUser.LastName;
            email = appUser.Email;
            joinDate = appUser.JoinDate;

            CampaignCount = appUser.Campaigns.Count;
        }
        //    {
        //        List<string> properties = new List<string>() {  };

        //        foreach (string property in properties)
        //       {

        //            Type type = properties.GetType();
        //                if (type == typeof(string))
        //                {
        //                    string stringValue = properties.ToString() as string;
        //                }
        //        }



        //propertyInfo[] properties = applicationUser.GetType().GetProperties();
        //Type objectType = obj.GetType();
        //PropertyInfo[] properties = objectType.GetProperties();

        //foreach (PropertyInfo info in properties)
        //{
        //    object value = info.GetValue(this, null);
        //    Type type = value.GetType();
        //    if (type == typeof(string))
        //    {
        //        string stringValue = value as string;
        //    }


        //in order to pass the properties into the controller/ view it might be better to put the properties into a list or an array rather than a stringubuilder, I was just playing around with this idea


    
        
    }
     
 }
