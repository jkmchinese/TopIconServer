using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace TopIconServer.Models
{
    /// <summary>
    /// 图标集
    /// </summary>
    public class Iconset : Entity
    {
        #region Fields

        private readonly IList<IconBase> m_icons;

        #endregion

        #region Constructors

        public Iconset()
        {
            m_icons = new List<IconBase>();
        }

        #endregion

        #region Properties

        [JsonIgnore]
        public IEnumerable<IconBase> Icons { get { return m_icons; } }

        #endregion

        #region Events

        #endregion

        #region Private Methods

        #endregion

        #region Protect Methods

        #endregion

        #region Public Methods

        public bool AddIcon(IconBase icon)
        {
            m_icons.Add(icon);
            return true;
        }

        #endregion
    }
}