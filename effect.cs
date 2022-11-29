using UnityEngine;

using AKB.Core.Managing;

namespace AKB.Entities.Interactions
{
    public abstract class StatusEffect : MonoBehaviour
    {
        [Header("Set in inspector")]
        [SerializeField] protected float activeTime;
        [SerializeField] protected EffectType effectType;
        [SerializeField] protected GameObject effectParticle;

        protected Entity attachedEntity;
        protected GameObject particleHolder;
        protected bool isActive = false;

        public abstract void OnEnable();

        public virtual void AttachToEntity()
        {
            attachedEntity = transform.root.GetComponent<Entity>();
        }

        public virtual void ApplyVFXToEntity(Entity attachedEntity)
        {
            particleHolder = new GameObject("Effect particles");
            particleHolder.transform.SetParent(attachedEntity.transform, false);

            Instantiate(effectParticle, particleHolder.transform);
        }

        public abstract void Update();

        public abstract void EffectBehaviour();

        public virtual void StopEffect()
        {
            attachedEntity = null;

            isActive = false;
        }

        public virtual void DestroyEffect()
        {
            Destroy(particleHolder);
            Destroy(gameObject);
        }

        public abstract void OnDisable();

        public Entity GetAttachedEntity() => attachedEntity;
    }
}
