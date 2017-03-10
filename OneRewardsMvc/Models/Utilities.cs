using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneRewardsMvc.Models
{
    public class Utilities
    {
        /// <summary>
        /// Converts the Image File to array of Bytes
        /// </summary>
        /// <param name="ImageFilePath">The path of the image file</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public byte[] ConvertImageFiletoBytes(string ImageFilePath)
        {
            byte[] _tempByte = null;
            if (string.IsNullOrEmpty(ImageFilePath) == true)
            {
                throw new ArgumentNullException("Image File Name Cannot be Null or Empty", "ImageFilePath");
            }
            try
            {
                System.IO.FileInfo _fileInfo = new System.IO.FileInfo(ImageFilePath);
                long _NumBytes = _fileInfo.Length;
                System.IO.FileStream _FStream = new System.IO.FileStream(ImageFilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                System.IO.BinaryReader _BinaryReader = new System.IO.BinaryReader(_FStream);
                _tempByte = _BinaryReader.ReadBytes(Convert.ToInt32(_NumBytes));
                _fileInfo = null;
                _NumBytes = 0;
                _FStream.Close();
                _FStream.Dispose();
                _BinaryReader.Close();
                return _tempByte;
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// Checks if user is authenticated.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool checkUser
        {
            get
            {
                return
                   HttpContext.Current.User != null &&
                   HttpContext.Current.User.Identity.IsAuthenticated;
            }
        }


        /// <summary>
        /// Checks if superUser is authenticated.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool superUser
        {
            get
            {
                return
                   HttpContext.Current.User != null &&
                   HttpContext.Current.User.Identity.IsAuthenticated && HttpContext.Current.User.IsInRole("Administrator");
            }
        }
    }
}