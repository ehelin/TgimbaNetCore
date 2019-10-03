using System.Security.Cryptography;

namespace BLLNetCore.Security
{
    public class Generator
    {
        public string GetPrivateKey() 
        {
            // TODO - re test this after .net core 3 is installed
            //RSA rsa = new RSACryptoServiceProvider(2048); // Generate a new 2048 bit RSA key
            //string key = rsa.ToXmlString(true);

            //NOTE: Temporary key generated from NetClassicUtility...replace when .net core has 
            //      same functionality as .Net Classic
            string key = "0AlLiz5y45wNRoCM3Hn2VDYPlP9Rz82Qd1R7OvyrcMuJ+O6kcb8hxrrCb8QYbs5hewMrxVi/9c51opWoH4ZSV6hGQC/y6cDxuePpXnGnlEhTWd7PSmDpc469ORBAPtetb8tLagE7GJebtoohTu/xnwrS5vZ8TrCTRC/h4Z/HyvWeXFu0zORHxv6REJgzArf/mjawYwQT0tFyde1lnXlKpVD+HKS6RLN5nTWbBLtaoxLj3eZsQb2GaVhbyW79RksNMkBajzXnd9KTak9+7N00q5mLzs2ourwk3BA0vVJ4+JjbRk7Mp2/YDX9praGH7KAFIuL/vkr0boHfn2Qf6rpvnQ==</Modulus><Exponent>AQAB</Exponent><P>2gY4Pgs/yn9gDf+LEuXTI/DO1gpJYKxjSz9pWJskZfkc+iim0ZoqLQUu7meao8t7Np1r/QLfyOCwwGNkqHR0E7ZpxH6Uv91abK4IBTwx2F621XUmCrDt8Ml2P1udoJeCGC0D8G5qll98fA6lvYvvFxRNOKcVUtEFAwlcvpBi62M=</P><Q>9EW1IYZevLuoeMaALwvdDWCQXS/vVq+8huTCB6zL4slsT/FpMBXYt+mC3pWy1etrxEE3zlP1s3ZwKLeFa5liyboENZDDvgCCI+9AKH0CNYvCRMMrHfyNBPZ4MAhFQ6UU4guHP8eUGgc8y20T9qsG2WmPs1hIuFFJnUxFO2MzqP8=</Q><DP>vzRDMM5mxG1OzRf2XL1nnRZ8HqRo07p7XiufdNCibDe7nPv3yMxd/puUHAqKSOmUBkKqyPozThUXjbHdPgrbHcqVGXk1dMpomfVKHWU8BZiS2cLieO/PzKKx7ECpjYQx2Ifp83qySWw2XQnverr1FJV+X5fQkI+0yIP2bT1tMyc=</DP><DQ>f5GQAMwd2c7fMwPnmapGbWAKxL/t7IWmnYQGWN/DMtMif7WBy5z9Kz8GG5xuYw2poDq3HEf4vxqRhJIjWYgncVZ2MEtEDoxRatbd2MdAShqNAEA02lo0g2z8Y4lOMv+ZoluG7KYcEGPLOinjDSVQVGaup2jpwWiiW0Wjuloadp0=</DQ><InverseQ>O12qjLHwkh+f7uWeBOcacylyoLTRI1t3mNLphhG46+xSZCryD9a/NC6mO//b/DSslRNoJnrjElW2XYygaxwqjNfBlEcD1yKByhnkPCxQWGA6OvTcLiM6b7PPKUBKU/zeGWJJ0UC8tuN71zssaBzAOVqYoWzFGdER/okq2/HvbcU=</InverseQ><D>PRSdk5KQVPe6hhq0QP+mLW95/7s/IA4w/nhVfio1g/ae2fHnYmZF2n13HS2sJsx9nop9zYGTSu6FZ2kdZbQgdRA5IBtz7OHzlyqtmEcydr0Ni/N5VVNC9+TO9fQpiMn2aD5+M++MlFnfJCdGRFD61kFtTtbMBKafdoPAhGhPVu1jB4/9glumfvGMb/sVxHRQQt7SJqoeydK5SYf33PdPEHCmD6Pu1elKnjqgwVmnknAKBvhfGtlqK5MQHuFzQFoMs5G7N4+gs82hYOVnGA3wDQAjmZWQW1PqKw5XTT0PpGvA0jO+uSgKBlNiMtjoNgxr50/zeDlC/laFnHhegUOL2Q==";

            return key;
        }
    }
}
