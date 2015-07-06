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
    /// 图标控制器
    /// </summary>
    public class IconsController : ApiController
    {
        /// <summary>
        /// 获取图标集下的所有图标
        /// </summary>
        /// <param name="iconSetID"></param>
        /// <returns></returns>
        public IEnumerable<IconBase> Get(string iconSetID)
        {
            var iconset = Repository.Instance.GetIconset(iconSetID);
            if (iconset == null)
            {
                return null;
            }
            return iconset.Icons;
        }

        /// <summary>
        /// 新建图标
        /// </summary>
        /// <param name="iconBase"></param>
        public void Post([FromBody]IconBase iconBase)
        {
            Repository.Instance.AddIcon(iconBase);
        }

        /// <summary>
        /// 更新图标
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public void Put(string id, [FromBody]string value)
        {
        }

        /// <summary>
        /// 删除图标
        /// </summary>
        /// <param name="id"></param>
        public void Delete(string id)
        {
        }
    }
}