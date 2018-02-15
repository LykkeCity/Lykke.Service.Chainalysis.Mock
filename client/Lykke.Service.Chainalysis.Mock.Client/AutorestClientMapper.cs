using AutoMapper;
using Lykke.Service.Chainalysis.Mock.Contracts;
using Lykke.Service.ChainalysisMock.Client.AutorestClient.Models;

namespace Lykke.Service.ChainalysisMock.Client
{
    public static class AutorestClientMapper
    {
        public static UserDepositAddressInfoModel ToContract(this IUserDepositAddressInfo info)
        {
            return Mapper.Map<UserDepositAddressInfoModel>(info);
        }

        public static UserTransactionInfoModel ToContract(this IUserTransactionInfo info)
        {
            return Mapper.Map<UserTransactionInfoModel>(info);
        }

        public static ReceiveOutputInfoModel ToContract(this IReceiveOutputInfo info)
        {
            return Mapper.Map<ReceiveOutputInfoModel>(info);
        }

        public static UserInfoModel ToContract(this IUserInfo info)
        {
            return Mapper.Map<UserInfoModel>(info);
        }

        public static UserDetailsModel ToContract(this IUserDetails info)
        {
            return Mapper.Map<UserDetailsModel>(info);
        }

        public static UserWithdrawAddressInfoModel ToContract(this IUserWithdrawAddressInfo info)
        {
            return Mapper.Map<UserWithdrawAddressInfoModel>(info);
        }


        public static WithdrawAddressInfoModel ToContract(this IWithdrawAddressInfo info)
        {
            return Mapper.Map<WithdrawAddressInfoModel>(info);
        }

        


    }
}
