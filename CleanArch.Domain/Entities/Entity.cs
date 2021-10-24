

using CleanArch.Domain.Validation;

namespace CleanArch.Domain.Entities {
    public abstract class Entity {
        protected Entity(int id)
        {
            ValidateDomain(id);
        }

        public Entity()
        {
            
        }
        public int Id { get; private set; }

        

        private void ValidateDomain(int id){
            DomainExceptionValidation.When(id <= 0, "Invalid Id value");

            this.Id = id;
        }
    }
}