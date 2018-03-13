using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public abstract class Entity<TKey>
    {
        #region properties

        /// <summary>
        /// Gets the identifier of the entity.
        /// </summary>
        public virtual TKey Id { get; protected set; }

        #endregion properties

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Entity{TKey}" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        protected Entity(TKey id)
        {
            Id = id;
        }

        #endregion constructors

        #region methods

        /// <summary>
        /// Determines whether the specified entity is equal to the current entity.
        /// </summary>
        /// <param name="obj">The entity to compare with the current entity.</param>
        /// <returns>
        ///     <c>true</c> if the entities are considered equal; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity<TKey>;

            if (ReferenceEquals(compareTo, null))
            {
                return false;
            }

            if (ReferenceEquals(this, compareTo))
            {
                return true;
            }

            if (GetType() != compareTo.GetType())
            {
                return false;
            }

            if (Id.Equals(compareTo.Id))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns the hash code for this entity.
        /// </summary>
        /// <returns>A hash code for the current entity.</returns>
        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }

        #endregion methods

        #region operators

        /// <summary>
        /// Determines whether two specified entities are equal.
        /// </summary>
        /// <param name="a">The first entity to compare, or <c>null</c>.</param>
        /// <param name="b">The second entity to compare, or <c>null</c>.</param>
        /// <returns>
        ///     <c>true</c> if the entities are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(Entity<TKey> a, Entity<TKey> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            {
                return true;
            }

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }

            return a.Equals(b);
        }

        /// <summary>
        /// Determines whether two specified entities are not equal.
        /// </summary>
        /// <param name="a">The first entity to compare, or <c>null</c>.</param>
        /// <param name="b">The second entity to compare, or <c>null</c>.</param>
        /// <returns>
        ///     <c>true</c> if the entities are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(Entity<TKey> a, Entity<TKey> b)
        {
            return !(a == b);
        }

        #endregion operators

        #region methods

        /// <summary>
        /// Sets the key.
        /// </summary>
        /// <param name="id">The identifier to be set.</param>
        public virtual void SetId(TKey id)
        {
            Id = id;
        }

        #endregion methods
    }
}
