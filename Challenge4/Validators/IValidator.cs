namespace Challenge4.Validators
{
    public interface IValidator<in T>
    {
        (bool valid, string reason) Validate(T testable);
    }
}