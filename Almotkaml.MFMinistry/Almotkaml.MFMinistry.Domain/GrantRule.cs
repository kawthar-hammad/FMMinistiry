
namespace Almotkaml.MFMinistry.Domain
{
    public class GrantRule
    {
        public static GrantRule Existed(int GrantRulesId, int grantId, Grantees grantees,Grant grant)
        {
           // Check.NotEmpty(name, nameof(name));
            Check.NotNull(grantees, nameof(grantees));
            Check.MoreThanZero(GrantRulesId, nameof(GrantRulesId));

            return new GrantRule()
            {
                GrantRuleId = GrantRulesId,
                GrantId = grantId,
                grantees = grantees,
                Grant = grant,
            };

        }
        public static GrantRule New(int grantId, Grantees grantees)
        {
           // Check.NotEmpty(name, nameof(name));
            Check.NotNull(grantees, nameof(grantees));

            var group = new GrantRule()
            {
                GrantId = grantId,
                grantees = grantees,
            };


            return group;
        }

        private GrantRule()
        {

        }

        public int GrantRuleId { get; private set; }
        public Grant Grant { get; private set; }
        public int GrantId { get; private set; }
        public Grantees grantees { get; private set; }

        public void Modify(int grantId, Grantees _grantees)
        {
           // Check.NotEmpty(name, nameof(name));
            Check.NotNull(grantees, nameof(grantees));

            GrantId = grantId;
            grantees = _grantees;

        }
    }
}
