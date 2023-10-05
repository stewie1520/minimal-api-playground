using playground.Entities;

namespace playground.Common.Exceptions;

public class NotFoundException<T>(Guid id) : ApplicationException($"Entity \"{typeof(T).Name}\" ({id}) was not found.")
    where T : BaseEntity;