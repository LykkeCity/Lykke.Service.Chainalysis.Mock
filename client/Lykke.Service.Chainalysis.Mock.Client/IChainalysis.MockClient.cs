using System.Threading.Tasks;
using Lykke.Service.Chainalysis.Mock.Contracts;
using AddressImportModel = Lykke.Service.ChainalysisMock.Client.AutorestClient.Models.AddressImportModel;
using CommentModel = Lykke.Service.ChainalysisMock.Client.AutorestClient.Models.CommentModel;
using OutputImportModel = Lykke.Service.ChainalysisMock.Client.AutorestClient.Models.OutputImportModel;
using UserImportModel = Lykke.Service.ChainalysisMock.Client.AutorestClient.Models.UserImportModel;

namespace Lykke.Service.ChainalysisMock.Client
{
    public interface IChainalysisMockClient
    {
        /// <summary>
        /// List deposit addresses associated with a user.
        /// </summary>
        /// <param name='userId'>
        /// The ID of the user
        /// </param>
        /// <param name='token'>
        /// API-key
        /// </param>
        /// <param name='limit'>
        /// The maximum number of items to return.
        /// </param>
        /// <param name='offset'>
        /// The offset into the result set
        /// </param>
        Task<UserDepositAddressInfoModel> GetAddressesDepositAsync(string userId, string token, int? limit = default(int?), int? offset = default(int?));

        /// <summary>
        /// <p>Add a deposit address associated with a user.</p>
        /// <p>
        /// <strong>Note</strong>: The user is automatically
        /// created if it does not exist.</p>
        /// <p>
        /// <strong>Note</strong>: The function is idempotent: If
        /// the deposit address is already associated with the user the
        /// function succeeds.</p>
        /// <p>
        /// <strong>Note</strong>: If the deposit address is
        /// associated with a different user the function fails (see Response
        /// Messages below).</p>
        /// </summary>
        /// <param name='userId'>
        /// The ID of the user
        /// </param>
        /// <param name='depositeAddress'>
        /// The deposit address
        /// </param>
        /// <param name='token'>
        /// API-key
        /// </param>
        Task<object> AddAddressesDepositAsync(string userId, AddressImportModel depositeAddress, string token);

        /// <summary>
        /// Delete a deposit address associated with a user.
        /// </summary>
        /// <param name='userId'>
        /// The ID of the user
        /// </param>
        /// <param name='address'>
        /// The address to delete
        /// </param>
        /// <param name='token'>
        /// API-key
        /// </param>
        Task<object> DeleteAddressesDepositAsync(string userId, string address, string token);

       
        /// <summary>
        /// <p>List received outputs associated with a user.</p>
        /// <p>For each output the following is listed:</p>
        /// <ul>
        /// <li>
        /// <p>
        /// <code>output</code>: the actual output</p>
        /// </li>
        /// <li>
        /// <p>
        /// <code>status</code>: the status of the output.Can
        /// be:</p>
        /// <ul>
        /// <li>
        /// <p>
        /// <code>unconfirmed</code>: if the transaction has not
        /// yet confirmed</p>
        /// </li>
        /// <li>
        /// <p>
        /// <code>confirmed</code>: if the transaction has
        /// confirmed, but not yet settled</p>
        /// </li>
        /// <li>
        /// <p>
        /// <code>settled</code>: if the transaction has at least 5
        /// confirmations.</p>
        /// </li>
        /// </ul>
        /// </li>
        /// </ul>
        /// <p>
        /// <strong>Note:</strong> Only settlet outputs take part
        /// in risk score calculations</p>
        /// <p>
        /// <strong>Note:</strong> Once an output has settled it
        /// cannot be deleted.</p>
        /// </summary>
        /// <param name='userId'>
        /// The ID of the user
        /// </param>
        /// <param name='token'>
        /// API-key
        /// </param>
        /// <param name='status'>
        /// The status of the output. Possible values include: 'Active',
        /// 'Committed', 'Aborted', 'InDoubt'
        /// </param>
        /// <param name='limit'>
        /// The maximum number of items to return.
        /// </param>
        /// <param name='offset'>
        /// The offset into the result set
        /// </param>
        Task<UserTransactionInfoModel> GetOutputsReceivedAsync(string userId, string token, TransactionStatus? status = default(TransactionStatus?), int? limit = default(int?), int? offset = default(int?));

        /// <summary>
        /// <p>Add a received output associated with a user.</p>
        /// <p>Call this function to register that your service has
        /// received a transaction output on behalf of a user.</p>
        /// <p>A transaction output can be specified in two
        /// ways:</p>
        /// <ol>
        /// <li>
        /// <strong>Transaction hash with output index.</strong>
        /// E.g.the second output of the transaction with the
        /// hash<code>77b8b931b3f7cd17e06dee680b77b28bb0809c88087343d657600730ca7ba15e</code>
        /// has index 1 and is specified like this
        /// <code>"77b8b931b3f7cd17e06dee680b77b28bb0809c88087343d657600730ca7ba15e:1"</code></li>
        /// <li>
        /// <strong>Transaction hash with output address.</strong>
        /// E.g.the second output of the transaction with the
        /// hash<code>77b8b931b3f7cd17e06dee680b77b28bb0809c88087343d657600730ca7ba15e</code>
        /// has output address
        /// <code>19eAxqvy3F3i2yNMWNjzwcKbSnMn9kpG1Z</code> and is
        /// specified like this
        /// <code>"77b8b931b3f7cd17e06dee680b77b28bb0809c88087343d657600730ca7ba15e:19eAxqvy3F3i2yNMWNjzwcKbSnMn9kpG1Z"</code></li>
        /// </ol>
        /// <p>The first form is preferred because the second form is
        /// ambigious in cases where the transaction has more than one output
        /// to the specified address.</p>
        /// <p>The return value contains a risk
        /// <code>score</code>, e.g. <code>red</code>,
        /// <code>amber</code>, or<code>
        /// green</code>:</p>
        /// <ul>
        /// <li>
        /// <p>
        /// <code>red</code>: This output was received directly
        /// from a suspicious sender.</p>
        /// </li>
        /// <li>
        /// <p>
        /// <code>amber</code>: This output was received from an
        /// unidentified sender.</p>
        /// </li>
        /// <li>
        /// <p>
        /// <code>green</code>: This output was received from an
        /// identified non-suspicious sender. </p>
        /// </li>
        /// </ul>
        /// <p>If the transaction has one or more confirmations and if
        /// the counterparty is identified the return value will
        /// contain<code> name</code> and<code>
        /// category</code> of the counterparty.</p>
        /// <p>
        /// <strong>Note</strong>: If the transaction has not yet
        /// confirmed<code> score</code> will be
        /// <code>amber</code>.Therefore it is advised to call this
        /// function twice, once your service observes the output, and once the
        /// transaction has confirmed, just before crediting the amount of the
        /// output to the user.</p>
        /// <p>
        /// <strong>Note</strong>: The user is automatically
        /// created if it does not exist.</p>
        /// <p>
        /// <strong>Note</strong>: The function is idempotent: If
        /// the sent output is already associated with the user the function
        /// succeeds.</p>
        /// <p>
        /// <strong>Note:</strong> If an output is not settled
        /// within 7 days it is silently discarded.</p>
        /// </summary>
        /// <param name='userId'>
        /// The ID of the user
        /// </param>
        /// <param name='output'>
        /// The transaction output
        /// </param>
        /// <param name='token'>
        /// API-key
        /// </param>
        Task<ReceiveOutputInfoModel> AddOutputsReceivedAsync(string userId, OutputImportModel output, string token);

        /// <summary>
        /// <p>Delete a received outputs associated with a
        /// user.</p>
        /// <p>
        /// <strong>Note:</strong> Once an output has settled it
        /// cannot be deleted.</p>
        /// </summary>
        /// <param name='userId'>
        /// The ID of the user
        /// </param>
        /// <param name='tx'>
        /// The hash of the transaction output
        /// </param>
        /// <param name='output'>
        /// The output index or output address
        /// </param>
        /// <param name='token'>
        /// API-key
        /// </param>
        Task<object> DeleteOutputsReceivedAsync(string userId, string tx, string output, string token);

        /// <summary>
        /// <p>List sent outputs associated with a user.</p>
        /// <p>For each output the following is listed:</p>
        /// <ul>
        /// <li>
        /// <p>
        /// <code>output</code>: the actual output</p>
        /// </li>
        /// <li>
        /// <p>
        /// <code>status</code>: the status of the output.Can
        /// be:</p>
        /// <ul>
        /// <li>
        /// <p>
        /// <code>unconfirmed</code>: if the transaction has not
        /// yet confirmed</p>
        /// </li>
        /// <li>
        /// <p>
        /// <code>confirmed</code>: if the transaction has
        /// confirmed, but not yet settled</p>
        /// </li>
        /// <li>
        /// <p>
        /// <code>settled</code>: if the transaction has at least 5
        /// confirmations.</p>
        /// </li>
        /// </ul>
        /// </li>
        /// </ul>
        /// <p>
        /// <strong>Note:</strong> Only settlet outputs take part
        /// in risk score calculations</p>
        /// <p>
        /// <strong>Note:</strong> Once an output has settled it
        /// cannot be deleted.</p>
        /// </summary>
        /// <param name='userId'>
        /// The ID of the user
        /// </param>
        /// <param name='token'>
        /// API-key
        /// </param>
        /// <param name='status'>
        /// The status of the output. Possible values include: 'unconfirmed',
        /// 'confirmed', 'settled', 'any'
        /// </param>
        /// <param name='limit'>
        /// The maximum number of items to return.
        /// </param>
        /// <param name='offset'>
        /// The offset into the result set
        /// </param>
        Task<UserTransactionInfoModel> GetOutputsSentAsync(string userId, string token, TransactionStatus? status = default(TransactionStatus?), int? limit = default(int?), int? offset = default(int?));

        /// <summary>
        /// <p>Add a sent output associated with a user.</p>
        /// <p>Call this function to register that your service has sent
        /// a transaction output on behalf of a user.</p>
        /// <p>A transaction output can be specified in two
        /// ways:</p>
        /// <ol>
        /// <li>
        /// <strong>Transaction hash with output index.</strong>
        /// E.g.the second output of the transaction with the
        /// hash<code>77b8b931b3f7cd17e06dee680b77b28bb0809c88087343d657600730ca7ba15e</code>
        /// has index 1 and is specified like this
        /// <code>"77b8b931b3f7cd17e06dee680b77b28bb0809c88087343d657600730ca7ba15e:1"</code></li>
        /// <li>
        /// <strong>Transaction hash with output address.</strong>
        /// E.g.the second output of the transaction with the
        /// hash<code>77b8b931b3f7cd17e06dee680b77b28bb0809c88087343d657600730ca7ba15e</code>
        /// has output address
        /// <code>19eAxqvy3F3i2yNMWNjzwcKbSnMn9kpG1Z</code> and is
        /// specified like this
        /// <code>"77b8b931b3f7cd17e06dee680b77b28bb0809c88087343d657600730ca7ba15e:19eAxqvy3F3i2yNMWNjzwcKbSnMn9kpG1Z"</code></li>
        /// </ol>
        /// <p>The first form is preferred because the second form is
        /// ambigious in cases where the transaction has more than one output
        /// to the specified address.</p>
        /// <p>
        /// <strong>Note</strong>: The user is automatically
        /// created if it does not exist.</p>
        /// <p>
        /// <strong>Note</strong>: The function is idempotent: If
        /// the sent output is already associated with the user the function
        /// succeeds.</p>
        /// <p>
        /// <strong>Note:</strong> If an output is not settled
        /// within 7 days it is silently discarded.</p>
        /// </summary>
        /// <param name='userId'>
        /// The ID of the user
        /// </param>
        /// <param name='output'>
        /// The transaction output
        /// </param>
        /// <param name='token'>
        /// API-key
        /// </param>
        Task<object> AddOutputsSentAsync(string userId, OutputImportModel output, string token);

        /// <summary>
        /// <p>Delete a sent outputs associated with a user.</p>
        /// <p>
        /// <strong>Note:</strong> Once an output has settled it
        /// cannot be deleted.</p>
        /// </summary>
        /// <param name='userId'>
        /// The ID of the user
        /// </param>
        /// <param name='tx'>
        /// The hash of the transaction output
        /// </param>
        /// <param name='output'>
        /// The output index or output address
        /// </param>
        /// <param name='token'>
        /// API-key
        /// </param>
        Task<object> DeleteOutputsSentAsync(string userId, string tx, string output, string token);

        /// <summary>
        /// <p>List users with optional filters.</p>
        /// <p>For each user the following is returned:</p>
        /// <ul>
        /// <li>
        /// <p>
        /// <code>userId</code>: the ID of the user</p>
        /// </li>
        /// <li>
        /// <p>
        /// <code>score</code>: the risk score of the user.E.g.
        /// <code>red</code>, <code>amber</code>,
        /// or<code> green</code>. Only included if the user has
        /// sent or received value.</p>
        /// </li>
        /// <li>
        /// <p>
        /// <code>scoreUpdatedDate</code>: the last time the risk
        /// score has been updated in POSIX format. Only included if the user
        /// has sent or received value.</p>
        /// </li>
        /// <li>
        /// <p>
        /// <code>lastActivity</code>: the last time the user sent
        /// or received value in POSIX format. Only included if the user has
        /// sent or received value.</p>
        /// </li>
        /// </ul>
        /// <p>Hint: to only return users with score<code>
        /// red</code> set the <code>score</code> parameter
        /// to<code> red</code></p>
        /// <p>Hint: To only return users that have sent or received
        /// value over the last 2 weeks set the<code>
        /// maxIdleDays</code> parameter to 14</p>
        /// </summary>
        /// <param name='token'>
        /// API-key
        /// </param>
        /// <param name='maxIdleDays'>
        /// Optionally filter the users by specifying the maximum numbers of
        /// days without sent or received activity.
        /// </param>
        /// <param name='score'>
        /// Optionally filter the users by specifying the risk score. Possible
        /// values include: 'red', 'amber', 'green'
        /// </param>
        /// <param name='limit'>
        /// The maximum number of items to return.
        /// </param>
        /// <param name='offset'>
        /// The offset into the result set
        /// </param>
        Task<UserInfoModel> GetUsersAsync(string token, int? maxIdleDays = default(int?), RiskScore? score = default(RiskScore?), int? limit = default(int?), int? offset = default(int?));

        /// <summary>
        /// <p>Import a user with sent and received history.</p>
        /// <p>With this function you can import a whole user with sent
        /// and received output history and all deposit and withdrawal
        /// addresses.</p>
        /// <p>The import format is as follows:</p>
        /// <ul>
        /// <li>
        /// <p>
        /// <code>userId</code>: the unique ID of the user. The
        /// caller decides the user ID and can specify any value containing the
        /// folllowing characters '-' '_' 'a-z' 'A-Z' '0-9' with a maximum of
        /// 200 characters.</p>
        /// </li>
        /// <li>
        /// <p>
        /// <code>depositAddresses</code>: The deposit addresses of
        /// the user. Specified as an array of strings where each address must
        /// be a valid Bitcoin addresses.</p>
        /// </li>
        /// <li>
        /// <p>
        /// <code>withdrawalAddresses</code>: The withdrawal
        /// addresses of the user. Specified as an array of strings where each
        /// address must be a valid Bitcoin addresses.</p>
        /// </li>
        /// <li>
        /// <p>
        /// <code>sentOutputs</code>: The transaction outputs sent
        /// by the user.See below for a specification on how to format an
        /// output.</p>
        /// </li>
        /// <li>
        /// <p>
        /// <code>receivedOutputs</code>: The transaction outputs
        /// received by the user.See below for a specification on how to format
        /// an output.</p>
        /// </li>
        /// </ul>
        /// <p>Sent or received outputs can be specified in two
        /// ways:</p>
        /// <ul>
        /// <li>
        /// <p>A transaction hash followed by the index of the output
        /// counting from zero:
        /// <code>tx-hash:output-index</code>.Exmaple: The first
        /// output of of the transaction<code>
        /// d03104f31dfbea2fa0e9c871790fbd1864d5b43354612c5b0b725eeb73bb7b8e</code>
        /// is specified like this
        /// <code>"d03104f31dfbea2fa0e9c871790fbd1864d5b43354612c5b0b725eeb73bb7b8e:0"</code>
        /// and the second output like this
        /// <code>"d03104f31dfbea2fa0e9c871790fbd1864d5b43354612c5b0b725eeb73bb7b8e:1"</code></p>
        /// </li>
        /// <li>
        /// <p>A transaction hash followed by the address of the output:
        /// <code>tx-hash:output-address</code>.Exmaple: The first
        /// output of of the transaction<code>
        /// d03104f31dfbea2fa0e9c871790fbd1864d5b43354612c5b0b725eeb73bb7b8e</code>
        /// is specified like this
        /// <code>"d03104f31dfbea2fa0e9c871790fbd1864d5b43354612c5b0b725eeb73bb7b8e:1ERWgzFdPwbAYM6GWg9dUX1Q3KssatXgYz"</code>
        /// and the second output like this
        /// <code>"d03104f31dfbea2fa0e9c871790fbd1864d5b43354612c5b0b725eeb73bb7b8e:16F5EJE8mgiEDJzKqRdWUzdB54WceDRfjx"</code></p>
        /// </li>
        /// </ul>
        /// <p>
        /// <strong>Note</strong>: The second output format can be
        /// ambigious in cases where the output address appears more than once
        /// in the outputs of a single transaction. If this occurs the first
        /// matching output is selected.</p>
        /// <p>
        /// <strong>Note</strong>: Importing a user with sent or
        /// received outputs with less than 5 confirmations will
        /// fail.</p>
        /// <p>
        /// <strong>Note</strong>: Subsequent import calls with the
        /// same userId are incremental, meaning that you can import another
        /// (E.g. new) version of a user on top of what is registered for that
        /// user already.In other words, any existing outputs or addresses
        /// which are not in the new import will NOT get deleted.</p>
        /// <p>
        /// <strong>Note</strong>: If one of the deposit addresses
        /// are associated with a different user the function fails(see
        /// Response Messages below).</p>
        /// </summary>
        /// <param name='userImport'>
        /// </param>
        /// <param name='token'>
        /// API-key
        /// </param>
        Task<string> ImportUserAsync(UserImportModel userImport, string token);

        /// <summary>
        /// <p>Get information about a user.</p>
        /// <p>The follwing information is returned:</p>
        /// <ul>
        /// <li>
        /// <p>
        /// <code>userId</code>: the ID of the user</p>
        /// </li>
        /// <li>
        /// <p>
        /// <code>creationDate</code>: the POSIX time when the user
        /// was created</p>
        /// </li>
        /// <li>
        /// <p>
        /// <code>comment</code>: an arbitrary string that can be
        /// set using another API function.Only included if set.</p>
        /// </li>
        /// <li>
        /// <p>
        /// <code>score</code>: the risk score of the user. E.g.
        /// <code>red</code>, <code>amber</code>,
        /// or<code> green</code>. Only included if the user has
        /// sent or received value.</p>
        /// </li>
        /// <li>
        /// <p>
        /// <code>scoreUpdatedDate</code>: the last time the risk
        /// score has been updated in POSIX format. Only included if the user
        /// has sent or received value.</p>
        /// </li>
        /// <li>
        /// <p>
        /// <code>lastActivity</code>: the last time the user sent
        /// or received value in POSIX format. Only included if the user has
        /// sent or received value.</p>
        /// </li>
        /// <li>
        /// <p>
        /// <code>exposureDetails</code>: detailed exposure
        /// data.Only included if the user has sent or received
        /// value.</p>
        /// <ul>
        /// <li>
        /// <p>
        /// <code>category</code>: exposure category.</p>
        /// </li>
        /// <li>
        /// <p>
        /// <code>sentIndirectExposure</code>: funds sent
        /// indirectly.</p>
        /// </li>
        /// <li>
        /// <p>
        /// <code>sentDirectExposure</code>: funds sent
        /// directly.</p>
        /// </li>
        /// <li>
        /// <p>
        /// <code>receivedIndirectExposure</code>: funds received
        /// indirectly.</p>
        /// </li>
        /// <li>
        /// <p>
        /// <code>receivedDirectExposure</code>: funds received
        /// directly.</p>
        /// </li>
        /// </ul>
        /// </li>
        /// </ul>
        /// </summary>
        /// <param name='userId'>
        /// The ID of the user
        /// </param>
        /// <param name='token'>
        /// API-key
        /// </param>
        Task<UserDetailsModel> GetUserAsync(string userId, string token);

        /// <summary>
        /// <p>Set the <code>comment</code> string on a
        /// user.</p>
        /// <p>This is a convenience function that allows you to set an
        /// arbitrary string for a user.When retrieving a user the string is
        /// returned.</p>
        /// </summary>
        /// <param name='userId'>
        /// The ID of the user
        /// </param>
        /// <param name='comment'>
        /// The deposit address
        /// </param>
        /// <param name='token'>
        /// API-key
        /// </param>
        Task<object> UpdateUserCommentAsync(string userId, CommentModel comment, string token);

        /// <summary>
        /// <p>List withdrawal addresses associated with a
        /// user.</p>
        /// <ul>
        /// <li>
        /// <p>Each withdrawal address is given a risk<code>
        /// score</code>. E.g. <code>red</code>,
        /// <code>amber</code>, or<code>
        /// green</code>.</p>
        /// </li>
        /// <li>
        /// <p>If a withdrawal address belongs to a known service,
        /// then<code> name</code> and<code>
        /// category</code> will be included and gives the name and
        /// category of that service. Otherwise<code> name</code>
        /// and<code> category</code> will be omitted.</p>
        /// </li>
        /// </ul>
        /// </summary>
        /// <param name='userId'>
        /// The ID of the user
        /// </param>
        /// <param name='token'>
        /// API-key
        /// </param>
        /// <param name='limit'>
        /// The maximum number of items to return.
        /// </param>
        /// <param name='offset'>
        /// The offset into the result set
        /// </param>
        Task<UserWithdrawAddressInfoModel> GetAddressesWithdrawalAsync(string userId, string token, int? limit = default(int?), int? offset = default(int?));

        /// <summary>
        /// <p>Add a withdrawal address associated with a user.</p>
        /// <ul>
        /// <li>
        /// <p>The user is automatically created if it does not
        /// exist.</p>
        /// </li>
        /// <li>
        /// <p>The function is idempotent: If the withdrawal address is
        /// already associated with the user the function succeeds.</p>
        /// </li>
        /// </ul>
        /// <p>The function returns an analysis of the withdrawal
        /// address:</p>
        /// <ul>
        /// <li>
        /// <p>A risk <code>score</code>.E.g.
        /// <code>red</code>, <code>amber</code>,
        /// or<code> green</code>.</p>
        /// </li>
        /// <li>
        /// <p>If a withdrawal address belongs to a known service,
        /// then<code> name</code> and<code>
        /// category</code> will be included and gives the name and
        /// category of that service. Otherwise<code> name</code>
        /// and<code> category</code> will be omitted.</p>
        /// </li>
        /// </ul>
        /// <p>Hint: This function could be called both when a user
        /// pastes in the withdrawal address for the first time, and also
        /// before each subsequent withdrawal.</p>
        /// </summary>
        /// <param name='userId'>
        /// The ID of the user
        /// </param>
        /// <param name='withdrawalAddress'>
        /// The withdrawal address
        /// </param>
        /// <param name='token'>
        /// API-key
        /// </param>
        Task<WithdrawAddressInfoModel> AddAddressesWithdrawalAsync(string userId, AddressImportModel withdrawalAddress, string token);

        /// <summary>
        /// Delete a withdrawal address associated with a user.
        /// </summary>
        /// <param name='userId'>
        /// The ID of the user
        /// </param>
        /// <param name='address'>
        /// The address to delete
        /// </param>
        /// <param name='token'>
        /// API-key
        /// </param>
        Task<object> DeleteAddressesWithdrawalAsync(string userId, string address, string token);
    }
}
