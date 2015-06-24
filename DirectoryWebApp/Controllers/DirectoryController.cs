using DirectoryCore.Models;
using DirectoryCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace DirectoryWebApp.Controllers
{
    public class DirectoryController : ApiController
    {
        public IDirectoryService DirectoryService { get; set; }

        [HttpPost]
        public Directory AddDirectory(Directory directory)
        {
            CheckDirectoryIsNotNullThrowException(directory);

            
                return DirectoryService.AddDirectory(directory);
            
            
        }

        [HttpPut]
        public Directory UpdateDirectory(Directory directory)
        {
            CheckDirectoryIsNullThrowException(directory);

                DirectoryService.UpdateDirectory(directory);
                return DirectoryService.GetDirectoryByName(directory.FriendDirectory_name);
           
        }

        [HttpDelete]
        public void DeleteDirectory(Directory directory)
        {
            try
            {
                DirectoryService.DeleteDirectory(directory);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public IList<Directory> GetAllDirectory()
        {
            return DirectoryService.GetAllDirectory();
        }

        [HttpGet]
        public Directory GetDirectoryById(Int64 id)
        {
            var course = DirectoryService.GetDirectoryById(id);

            if (course == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return course;
        }

        [HttpGet]
        [ActionName("Name")]
        public Directory GetDirectoryByName(string input)
        {
            var course = DirectoryService.GetDirectoryByName(input);

            if (course == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return course;
        }

        /// <summary>
        ///     檢查課程資料是否存在，如果不存在則拋出錯誤.
        /// </summary>
        /// <param name="directory">
        ///     課程資料.
        /// </param>
        private void CheckDirectoryIsNullThrowException(Directory directory)
        {
            Directory dbCourse = DirectoryService.GetDirectoryById(directory.FriendDirectory_id);

            if (dbCourse == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        ///     檢查通訊錄資料是否存在，如果存在則拋出錯誤.
        /// </summary>
        /// <param name="directory">
        ///     通訊錄資料.
        /// </param>
        private void CheckDirectoryIsNotNullThrowException(Directory directory)
        {
            Directory dbCourse = DirectoryService.GetDirectoryById(directory.FriendDirectory_id);

            if (dbCourse != null)
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
        }
    }
}