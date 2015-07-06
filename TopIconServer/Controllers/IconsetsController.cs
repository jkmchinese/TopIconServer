using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TopIconServer.Models;

namespace TopIconServer.Controllers
{
    /// <summary>
    /// 图标集控制器
    /// </summary>
    public class IconsetsController : ApiController
    {
        /// <summary>
        /// 获取所有的图标集
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Iconset> Get()
        {
            return Repository.Instance.GetIconsets();
        }

        /// <summary>
        /// 获取特定ID的图标集
        /// </summary>
        /// <param name="iconsetID"></param>
        /// <returns></returns>
        public Iconset Get(string iconsetID)
        {
            return Repository.Instance.GetIconset(iconsetID);
        }

        /// <summary>
        /// 获取图标集中更新的图标ID
        /// </summary>
        /// <param name="iconsetID"></param>
        /// <param name="iconsetModifyDateTime"></param>
        /// <returns></returns>
        public IEnumerable<string> GetUpdateIconsID(string iconsetID, DateTime iconsetModifyDateTime)
        {
            var iconset = Repository.Instance.GetIconset(iconsetID);
            if (iconset == null)
            {
                return new List<string>();
            }
            return from icon in iconset.Icons
                   where icon.ModifiedTime < iconsetModifyDateTime
                   select icon.ID;
            //return iconset.Icons.Where(o => o.ModifiedTime < iconsetModifyDateTime).Select(o => o.ID);
        }

        /// <summary>
        /// 新建图标集
        /// </summary>
        /// <param name="value"></param>
        public void Post([FromBody]Iconset value)
        {
            Repository.Instance.AddIconset(value);
        }

        /// <summary>
        /// 更新图标集
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public void Put(string id, [FromBody]Iconset value)
        {
        }

        /// <summary>
        /// 删除图标集
        /// </summary>
        /// <param name="id"></param>
        public void Delete(string id)
        {
        }
    }
}