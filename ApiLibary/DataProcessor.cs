using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiLibary
{
    /// <summary>
    /// Class that handles and process the data back and forward from the Api client
    /// </summary>
    public class DataProcessor
    {
        /// <summary>
        /// Get's a person or returns the person lists.
        /// Is Async due we are requesting something on the WWW, and don't want to lock the user
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        public async Task<PersonModel> GetPerson(int personId)
        {
            //-- Url holder
            string url = "";

            //-- Checks wether or not the number is zero, if not then we return the whole list
            if(personId > 0)
            {
                url = $"http://localhost:44398/Api/People/"+$"{personId}";
            }
            else
            {
                url = $"http://localhost:44398/Api/People"; 
            }

            //-- Opens up a new Http request from the ApiClient created with the url path.
            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(url))
            {
                //-- If it's successfull, we can do something with the returned data.
                if(response.IsSuccessStatusCode)
                {
                    //-- Awaits the response of the content requested in async, but it must convert into a PersonModel
                    //-- Here it will match it's content, to the properties stored in the PersonModel object.
                    PersonModel person = await response.Content.ReadAsAsync<PersonModel>();

                    return person;
                }
                else
                {
                    //-- Throws an exception if it's not successful
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
