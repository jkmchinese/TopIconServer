using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace TopIconServer.Models
{
    /// <summary>
    /// 图标仓库
    /// </summary>
    public class Repository
    {
        #region Fields

        private static readonly Repository _instance = new Repository();
        private readonly IList<Iconset> m_iconSets;
        private readonly string m_appData = Path.Combine(AppDomain.CurrentDomain.RelativeSearchPath, @"App_Data");
        private const string FILEEXTEND = ".json";

        #endregion

        #region Constructors

        static Repository()
        {

        }

        public Repository()
        {
            m_iconSets = new List<Iconset>();
            LoadData();
        }

        #endregion

        #region Properties

        public static Repository Instance { get { return _instance; } }

        #endregion

        #region Events

        #endregion

        #region Private Methods

        private void LoadData()
        {
            foreach (var file in Directory.GetFiles(m_appData))
            {
                if (Path.GetExtension(file) == FILEEXTEND)
                {
                    LoadFile(file);
                }
            }
        }

        private void LoadFile(string file)
        {
            m_iconSets.Add(JsonConvert.DeserializeObject<Iconset>(File.ReadAllText(file)));

            //var set = m_iconSets.FirstOrDefault();
            //var fileName = Path.Combine(AppDomain.CurrentDomain.RelativeSearchPath, APPDATA, set.Name + FILEEXTEND);
            //File.WriteAllText(fileName, JsonConvert.SerializeObject(set));
        }

        private void SaveIconset(Iconset set)
        {
            var fileName = Path.Combine(m_appData, set.Name + FILEEXTEND);
            File.WriteAllText(fileName, JsonConvert.SerializeObject(set));
        }

        private void AddIconCore(IconBase icon, Iconset iconSet)
        {
            DateTime now = DateTime.Now;
            icon.CreateTime = now;
            iconSet.ModifiedTime = now;
            iconSet.AddIcon(icon);
            SaveIconset(iconSet);
        }

        #endregion

        #region Protect Methods

        #endregion

        #region Public Methods

        internal IEnumerable<Iconset> GetIconsets()
        {
            return m_iconSets;
        }

        internal Iconset GetIconset(string iconSetID)
        {
            return m_iconSets.FirstOrDefault(o => o.ID == iconSetID);
        }

        internal bool AddIconset(Iconset iconset)
        {
            iconset.CreateTime = DateTime.Now;
            m_iconSets.Add(iconset);
            SaveIconset(iconset);
            return true;
        }

        internal IEnumerable<IconBase> GetIcon(string iconSetID)
        {
            var iconSet = m_iconSets.FirstOrDefault(o => o.ID == iconSetID);
            if (iconSet != null)
                return iconSet.Icons;

            return new List<IconBase>();
        }

        internal bool AddIcon(IconBase icon)
        {
            var iconSet = m_iconSets.FirstOrDefault(o => o.ID == icon.IconsetID);
            if (iconSet == null)
            {
                return false;
            }
            AddIconCore(icon, iconSet);
            return true;
        }

        #endregion
    }
}