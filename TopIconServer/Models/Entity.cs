using System;

namespace TopIconServer.Models
{
    /// <summary>
    /// 实体
    /// </summary>
    public class Entity
    {
        public Entity()
        {
            CreateTime = DateTime.Now;
            ModifiedTime = DateTime.Now;
        }

        public string ID { get; set; }
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifiedTime { get; set; }
    }
}