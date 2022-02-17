
using GameFramework.DataTable;
using System;
using UnityGameFramework.Runtime;


namespace Laputa
{
    public static class EntityExtension
    {
        // ���� EntityId ��Լ����
        // 0 Ϊ��Ч
        // ��ֵ���ںͷ�����ͨ�ŵ�ʵ�壨����ҽ�ɫ��NPC���ֵȣ�������ֻ������ֵ��
        // ��ֵ���ڱ������ɵ���ʱʵ�壨����Ч��FakeObject�ȣ�
        private static int s_SerialId = 0;

        public static Entity GetGameEntity(this EntityComponent entityComponent, int entityId)
        {
            UnityGameFramework.Runtime.Entity entity = entityComponent.GetEntity(entityId);
            if (entity == null)
            {
                return null;
            }

            return (Entity)entity.Logic;
        }

        public static void HideEntity(this EntityComponent entityComponent, Entity entity)
        {
            entityComponent.HideEntity(entity.Entity);
        }

        public static void AttachEntity(this EntityComponent entityComponent, Entity entity, int ownerId, string parentTransformPath = null, object userData = null)
        {
            entityComponent.AttachEntity(entity.Entity, ownerId, parentTransformPath, userData);
        }

        public static void ShowPlayer(this EntityComponent entityComponent, PlayerData data)
        {
            entityComponent.ShowEntity(typeof(Player), "Player", Constant.AssetPriority.AircraftAsset, data);
        }

        public static void ShowBox(this EntityComponent entityComponent, BoxData data)
        {
            entityComponent.ShowEntity(typeof(Box), "Environment", Constant.AssetPriority.AircraftAsset, data);
        }



        //public static void ShowMyAircraft(this EntityComponent entityComponent, MyAircraftData data)
        //{
        //    entityComponent.ShowEntity(typeof(MyAircraft), "Aircraft", Constant.AssetPriority.MyAircraftAsset, data);
        //}

        //public static void ShowAircraft(this EntityComponent entityComponent, AircraftData data)
        //{
        //    entityComponent.ShowEntity(typeof(Aircraft), "Aircraft", Constant.AssetPriority.AircraftAsset, data);
        //}

        //public static void ShowThruster(this EntityComponent entityComponent, ThrusterData data)
        //{
        //    entityComponent.ShowEntity(typeof(Thruster), "Thruster", Constant.AssetPriority.ThrusterAsset, data);
        //}

        //public static void ShowWeapon(this EntityComponent entityComponent, WeaponData data)
        //{
        //    entityComponent.ShowEntity(typeof(Weapon), "Weapon", Constant.AssetPriority.WeaponAsset, data);
        //}

        //public static void ShowArmor(this EntityComponent entityComponent, ArmorData data)
        //{
        //    entityComponent.ShowEntity(typeof(Armor), "Armor", Constant.AssetPriority.ArmorAsset, data);
        //}

        //public static void ShowBullet(this EntityComponent entityCompoennt, BulletData data)
        //{
        //    entityCompoennt.ShowEntity(typeof(Bullet), "Bullet", Constant.AssetPriority.BulletAsset, data);
        //}

        //public static void ShowAsteroid(this EntityComponent entityCompoennt, AsteroidData data)
        //{
        //    entityCompoennt.ShowEntity(typeof(Asteroid), "Asteroid", Constant.AssetPriority.AsteroiAsset, data);
        //}

        //public static void ShowEffect(this EntityComponent entityComponent, EffectData data)
        //{
        //    entityComponent.ShowEntity(typeof(Effect), "Effect", Constant.AssetPriority.EffectAsset, data);
        //}
        // ��̬����EntityComponent���������ShowEntity������
        private static void ShowEntity(this EntityComponent entityComponent, Type logicType, string entityGroup, int priority, EntityData data)
        {
            if (data == null)
            {
                Log.Warning("Data is invalid.");
                return;
            }

            IDataTable<DREntity> dtEntity = GameEntry.DataTable.GetDataTable<DREntity>();
            DREntity drEntity = dtEntity.GetDataRow(data.TypeId);
            if (drEntity == null)
            {
                Log.Warning("Can not load entity id '{0}' from data table.", data.TypeId.ToString());
                return;
            }

            entityComponent.ShowEntity(data.Id, logicType, AssetUtility.GetEntityAsset(drEntity.AssetName), entityGroup, priority, data);
        }

        public static int GenerateSerialId(this EntityComponent entityComponent)
        {
            return --s_SerialId;
        }
    }
}
