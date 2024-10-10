namespace BackendBG.Utilitarios
{
    public class DynamicEmpty
    {
        public bool IsDynamicEmpty(dynamic obj)
        {
            if (obj is IEnumerable<dynamic> list)
            {
                return !list.Any();
            }
            else if (obj == null)
            {
                return true;
            }
            return false;
        }

    }
}
