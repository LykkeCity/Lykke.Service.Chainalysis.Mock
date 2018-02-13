﻿
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Lykke.Service.ChainalysisMock.Client.AutorestClient.Models;
using Lykke.Service.ChainalysisMock.Client.Models;
using Microsoft.Rest;

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
        Task<UserDepositAddressInfoModel> UserByUserIdAddressesDepositGetWithHttpMessagesAsync(string userId, string token, int? limit = default(int?), int? offset = default(int?));

        /// <summary>
        /// &lt;p&gt;Add a deposit address associated with a user.&lt;/p&gt;
        /// &lt;p&gt;
        /// &lt;strong&gt;Note&lt;/strong&gt;: The user is automatically
        /// created if it does not exist.&lt;/p&gt;
        /// &lt;p&gt;
        /// &lt;strong&gt;Note&lt;/strong&gt;: The function is idempotent: If
        /// the deposit address is already associated with the user the
        /// function succeeds.&lt;/p&gt;
        /// &lt;p&gt;
        /// &lt;strong&gt;Note&lt;/strong&gt;: If the deposit address is
        /// associated with a different user the function fails (see Response
        /// Messages below).&lt;/p&gt;
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
        Task<object> UserByUserIdAddressesDepositPostWithHttpMessagesAsync(string userId, AddressImportModel depositeAddress, string token);

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
        Task<object> UserByUserIdAddressesDepositByAddressDeleteWithHttpMessagesAsync(string userId, string address, string token);

       
        /// <summary>
        /// &lt;p&gt;List received outputs associated with a user.&lt;/p&gt;
        /// &lt;p&gt;For each output the following is listed:&lt;/p&gt;
        /// &lt;ul&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;
        /// &lt;code&gt;output&lt;/code&gt;: the actual output&lt;/p&gt;
        /// &lt;/li&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;
        /// &lt;code&gt;status&lt;/code&gt;: the status of the output.Can
        /// be:&lt;/p&gt;
        /// &lt;ul&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;
        /// &lt;code&gt;unconfirmed&lt;/code&gt;: if the transaction has not
        /// yet confirmed&lt;/p&gt;
        /// &lt;/li&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;
        /// &lt;code&gt;confirmed&lt;/code&gt;: if the transaction has
        /// confirmed, but not yet settled&lt;/p&gt;
        /// &lt;/li&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;
        /// &lt;code&gt;settled&lt;/code&gt;: if the transaction has at least 5
        /// confirmations.&lt;/p&gt;
        /// &lt;/li&gt;
        /// &lt;/ul&gt;
        /// &lt;/li&gt;
        /// &lt;/ul&gt;
        /// &lt;p&gt;
        /// &lt;strong&gt;Note:&lt;/strong&gt; Only settlet outputs take part
        /// in risk score calculations&lt;/p&gt;
        /// &lt;p&gt;
        /// &lt;strong&gt;Note:&lt;/strong&gt; Once an output has settled it
        /// cannot be deleted.&lt;/p&gt;
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
        Task<UserTransactionInfoModel> UserByUserIdOutputsReceivedGetWithHttpMessagesAsync(string userId, string token, string status = default(string), int? limit = default(int?), int? offset = default(int?));

        /// <summary>
        /// &lt;p&gt;Add a received output associated with a user.&lt;/p&gt;
        /// &lt;p&gt;Call this function to register that your service has
        /// received a transaction output on behalf of a user.&lt;/p&gt;
        /// &lt;p&gt;A transaction output can be specified in two
        /// ways:&lt;/p&gt;
        /// &lt;ol&gt;
        /// &lt;li&gt;
        /// &lt;strong&gt;Transaction hash with output index.&lt;/strong&gt;
        /// E.g.the second output of the transaction with the
        /// hash&lt;code&gt;77b8b931b3f7cd17e06dee680b77b28bb0809c88087343d657600730ca7ba15e&lt;/code&gt;
        /// has index 1 and is specified like this
        /// &lt;code&gt;"77b8b931b3f7cd17e06dee680b77b28bb0809c88087343d657600730ca7ba15e:1"&lt;/code&gt;&lt;/li&gt;
        /// &lt;li&gt;
        /// &lt;strong&gt;Transaction hash with output address.&lt;/strong&gt;
        /// E.g.the second output of the transaction with the
        /// hash&lt;code&gt;77b8b931b3f7cd17e06dee680b77b28bb0809c88087343d657600730ca7ba15e&lt;/code&gt;
        /// has output address
        /// &lt;code&gt;19eAxqvy3F3i2yNMWNjzwcKbSnMn9kpG1Z&lt;/code&gt; and is
        /// specified like this
        /// &lt;code&gt;"77b8b931b3f7cd17e06dee680b77b28bb0809c88087343d657600730ca7ba15e:19eAxqvy3F3i2yNMWNjzwcKbSnMn9kpG1Z"&lt;/code&gt;&lt;/li&gt;
        /// &lt;/ol&gt;
        /// &lt;p&gt;The first form is preferred because the second form is
        /// ambigious in cases where the transaction has more than one output
        /// to the specified address.&lt;/p&gt;
        /// &lt;p&gt;The return value contains a risk
        /// &lt;code&gt;score&lt;/code&gt;, e.g. &lt;code&gt;red&lt;/code&gt;,
        /// &lt;code&gt;amber&lt;/code&gt;, or&lt;code&gt;
        /// green&lt;/code&gt;:&lt;/p&gt;
        /// &lt;ul&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;
        /// &lt;code&gt;red&lt;/code&gt;: This output was received directly
        /// from a suspicious sender.&lt;/p&gt;
        /// &lt;/li&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;
        /// &lt;code&gt;amber&lt;/code&gt;: This output was received from an
        /// unidentified sender.&lt;/p&gt;
        /// &lt;/li&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;
        /// &lt;code&gt;green&lt;/code&gt;: This output was received from an
        /// identified non-suspicious sender. &lt;/p&gt;
        /// &lt;/li&gt;
        /// &lt;/ul&gt;
        /// &lt;p&gt;If the transaction has one or more confirmations and if
        /// the counterparty is identified the return value will
        /// contain&lt;code&gt; name&lt;/code&gt; and&lt;code&gt;
        /// category&lt;/code&gt; of the counterparty.&lt;/p&gt;
        /// &lt;p&gt;
        /// &lt;strong&gt;Note&lt;/strong&gt;: If the transaction has not yet
        /// confirmed&lt;code&gt; score&lt;/code&gt; will be
        /// &lt;code&gt;amber&lt;/code&gt;.Therefore it is advised to call this
        /// function twice, once your service observes the output, and once the
        /// transaction has confirmed, just before crediting the amount of the
        /// output to the user.&lt;/p&gt;
        /// &lt;p&gt;
        /// &lt;strong&gt;Note&lt;/strong&gt;: The user is automatically
        /// created if it does not exist.&lt;/p&gt;
        /// &lt;p&gt;
        /// &lt;strong&gt;Note&lt;/strong&gt;: The function is idempotent: If
        /// the sent output is already associated with the user the function
        /// succeeds.&lt;/p&gt;
        /// &lt;p&gt;
        /// &lt;strong&gt;Note:&lt;/strong&gt; If an output is not settled
        /// within 7 days it is silently discarded.&lt;/p&gt;
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
        Task<ReceiveOutputInfoModel> UserByUserIdOutputsReceivedPostWithHttpMessagesAsync(string userId, OutputImportModel output, string token);

        /// <summary>
        /// &lt;p&gt;Delete a received outputs associated with a
        /// user.&lt;/p&gt;
        /// &lt;p&gt;
        /// &lt;strong&gt;Note:&lt;/strong&gt; Once an output has settled it
        /// cannot be deleted.&lt;/p&gt;
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
        Task<object> UserByUserIdOutputsReceivedByTxByOutputDeleteWithHttpMessagesAsync(string userId, string tx, string output, string token);

        /// <summary>
        /// &lt;p&gt;List sent outputs associated with a user.&lt;/p&gt;
        /// &lt;p&gt;For each output the following is listed:&lt;/p&gt;
        /// &lt;ul&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;
        /// &lt;code&gt;output&lt;/code&gt;: the actual output&lt;/p&gt;
        /// &lt;/li&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;
        /// &lt;code&gt;status&lt;/code&gt;: the status of the output.Can
        /// be:&lt;/p&gt;
        /// &lt;ul&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;
        /// &lt;code&gt;unconfirmed&lt;/code&gt;: if the transaction has not
        /// yet confirmed&lt;/p&gt;
        /// &lt;/li&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;
        /// &lt;code&gt;confirmed&lt;/code&gt;: if the transaction has
        /// confirmed, but not yet settled&lt;/p&gt;
        /// &lt;/li&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;
        /// &lt;code&gt;settled&lt;/code&gt;: if the transaction has at least 5
        /// confirmations.&lt;/p&gt;
        /// &lt;/li&gt;
        /// &lt;/ul&gt;
        /// &lt;/li&gt;
        /// &lt;/ul&gt;
        /// &lt;p&gt;
        /// &lt;strong&gt;Note:&lt;/strong&gt; Only settlet outputs take part
        /// in risk score calculations&lt;/p&gt;
        /// &lt;p&gt;
        /// &lt;strong&gt;Note:&lt;/strong&gt; Once an output has settled it
        /// cannot be deleted.&lt;/p&gt;
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
        Task<UserTransactionInfoModel> UserByUserIdOutputsSentGetWithHttpMessagesAsync(string userId, string token, string status = default(string), int? limit = default(int?), int? offset = default(int?));

        /// <summary>
        /// &lt;p&gt;Add a sent output associated with a user.&lt;/p&gt;
        /// &lt;p&gt;Call this function to register that your service has sent
        /// a transaction output on behalf of a user.&lt;/p&gt;
        /// &lt;p&gt;A transaction output can be specified in two
        /// ways:&lt;/p&gt;
        /// &lt;ol&gt;
        /// &lt;li&gt;
        /// &lt;strong&gt;Transaction hash with output index.&lt;/strong&gt;
        /// E.g.the second output of the transaction with the
        /// hash&lt;code&gt;77b8b931b3f7cd17e06dee680b77b28bb0809c88087343d657600730ca7ba15e&lt;/code&gt;
        /// has index 1 and is specified like this
        /// &lt;code&gt;"77b8b931b3f7cd17e06dee680b77b28bb0809c88087343d657600730ca7ba15e:1"&lt;/code&gt;&lt;/li&gt;
        /// &lt;li&gt;
        /// &lt;strong&gt;Transaction hash with output address.&lt;/strong&gt;
        /// E.g.the second output of the transaction with the
        /// hash&lt;code&gt;77b8b931b3f7cd17e06dee680b77b28bb0809c88087343d657600730ca7ba15e&lt;/code&gt;
        /// has output address
        /// &lt;code&gt;19eAxqvy3F3i2yNMWNjzwcKbSnMn9kpG1Z&lt;/code&gt; and is
        /// specified like this
        /// &lt;code&gt;"77b8b931b3f7cd17e06dee680b77b28bb0809c88087343d657600730ca7ba15e:19eAxqvy3F3i2yNMWNjzwcKbSnMn9kpG1Z"&lt;/code&gt;&lt;/li&gt;
        /// &lt;/ol&gt;
        /// &lt;p&gt;The first form is preferred because the second form is
        /// ambigious in cases where the transaction has more than one output
        /// to the specified address.&lt;/p&gt;
        /// &lt;p&gt;
        /// &lt;strong&gt;Note&lt;/strong&gt;: The user is automatically
        /// created if it does not exist.&lt;/p&gt;
        /// &lt;p&gt;
        /// &lt;strong&gt;Note&lt;/strong&gt;: The function is idempotent: If
        /// the sent output is already associated with the user the function
        /// succeeds.&lt;/p&gt;
        /// &lt;p&gt;
        /// &lt;strong&gt;Note:&lt;/strong&gt; If an output is not settled
        /// within 7 days it is silently discarded.&lt;/p&gt;
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
        Task<object> UserByUserIdOutputsSentPostWithHttpMessagesAsync(string userId, OutputImportModel output, string token);

        /// <summary>
        /// &lt;p&gt;Delete a sent outputs associated with a user.&lt;/p&gt;
        /// &lt;p&gt;
        /// &lt;strong&gt;Note:&lt;/strong&gt; Once an output has settled it
        /// cannot be deleted.&lt;/p&gt;
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
        Task<object> UserByUserIdOutputsSentByTxByOutputDeleteWithHttpMessagesAsync(string userId, string tx, string output, string token);

        /// <summary>
        /// &lt;p&gt;List users with optional filters.&lt;/p&gt;
        /// &lt;p&gt;For each user the following is returned:&lt;/p&gt;
        /// &lt;ul&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;
        /// &lt;code&gt;userId&lt;/code&gt;: the ID of the user&lt;/p&gt;
        /// &lt;/li&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;
        /// &lt;code&gt;score&lt;/code&gt;: the risk score of the user.E.g.
        /// &lt;code&gt;red&lt;/code&gt;, &lt;code&gt;amber&lt;/code&gt;,
        /// or&lt;code&gt; green&lt;/code&gt;. Only included if the user has
        /// sent or received value.&lt;/p&gt;
        /// &lt;/li&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;
        /// &lt;code&gt;scoreUpdatedDate&lt;/code&gt;: the last time the risk
        /// score has been updated in POSIX format. Only included if the user
        /// has sent or received value.&lt;/p&gt;
        /// &lt;/li&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;
        /// &lt;code&gt;lastActivity&lt;/code&gt;: the last time the user sent
        /// or received value in POSIX format. Only included if the user has
        /// sent or received value.&lt;/p&gt;
        /// &lt;/li&gt;
        /// &lt;/ul&gt;
        /// &lt;p&gt;Hint: to only return users with score&lt;code&gt;
        /// red&lt;/code&gt; set the &lt;code&gt;score&lt;/code&gt; parameter
        /// to&lt;code&gt; red&lt;/code&gt;&lt;/p&gt;
        /// &lt;p&gt;Hint: To only return users that have sent or received
        /// value over the last 2 weeks set the&lt;code&gt;
        /// maxIdleDays&lt;/code&gt; parameter to 14&lt;/p&gt;
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
        Task<UserInfoModel> UserGetWithHttpMessagesAsync(string token, int? maxIdleDays = default(int?), string score = default(string), int? limit = default(int?), int? offset = default(int?));

        /// <summary>
        /// &lt;p&gt;Import a user with sent and received history.&lt;/p&gt;
        /// &lt;p&gt;With this function you can import a whole user with sent
        /// and received output history and all deposit and withdrawal
        /// addresses.&lt;/p&gt;
        /// &lt;p&gt;The import format is as follows:&lt;/p&gt;
        /// &lt;ul&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;
        /// &lt;code&gt;userId&lt;/code&gt;: the unique ID of the user. The
        /// caller decides the user ID and can specify any value containing the
        /// folllowing characters '-' '_' 'a-z' 'A-Z' '0-9' with a maximum of
        /// 200 characters.&lt;/p&gt;
        /// &lt;/li&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;
        /// &lt;code&gt;depositAddresses&lt;/code&gt;: The deposit addresses of
        /// the user. Specified as an array of strings where each address must
        /// be a valid Bitcoin addresses.&lt;/p&gt;
        /// &lt;/li&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;
        /// &lt;code&gt;withdrawalAddresses&lt;/code&gt;: The withdrawal
        /// addresses of the user. Specified as an array of strings where each
        /// address must be a valid Bitcoin addresses.&lt;/p&gt;
        /// &lt;/li&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;
        /// &lt;code&gt;sentOutputs&lt;/code&gt;: The transaction outputs sent
        /// by the user.See below for a specification on how to format an
        /// output.&lt;/p&gt;
        /// &lt;/li&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;
        /// &lt;code&gt;receivedOutputs&lt;/code&gt;: The transaction outputs
        /// received by the user.See below for a specification on how to format
        /// an output.&lt;/p&gt;
        /// &lt;/li&gt;
        /// &lt;/ul&gt;
        /// &lt;p&gt;Sent or received outputs can be specified in two
        /// ways:&lt;/p&gt;
        /// &lt;ul&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;A transaction hash followed by the index of the output
        /// counting from zero:
        /// &lt;code&gt;tx-hash:output-index&lt;/code&gt;.Exmaple: The first
        /// output of of the transaction&lt;code&gt;
        /// d03104f31dfbea2fa0e9c871790fbd1864d5b43354612c5b0b725eeb73bb7b8e&lt;/code&gt;
        /// is specified like this
        /// &lt;code&gt;"d03104f31dfbea2fa0e9c871790fbd1864d5b43354612c5b0b725eeb73bb7b8e:0"&lt;/code&gt;
        /// and the second output like this
        /// &lt;code&gt;"d03104f31dfbea2fa0e9c871790fbd1864d5b43354612c5b0b725eeb73bb7b8e:1"&lt;/code&gt;&lt;/p&gt;
        /// &lt;/li&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;A transaction hash followed by the address of the output:
        /// &lt;code&gt;tx-hash:output-address&lt;/code&gt;.Exmaple: The first
        /// output of of the transaction&lt;code&gt;
        /// d03104f31dfbea2fa0e9c871790fbd1864d5b43354612c5b0b725eeb73bb7b8e&lt;/code&gt;
        /// is specified like this
        /// &lt;code&gt;"d03104f31dfbea2fa0e9c871790fbd1864d5b43354612c5b0b725eeb73bb7b8e:1ERWgzFdPwbAYM6GWg9dUX1Q3KssatXgYz"&lt;/code&gt;
        /// and the second output like this
        /// &lt;code&gt;"d03104f31dfbea2fa0e9c871790fbd1864d5b43354612c5b0b725eeb73bb7b8e:16F5EJE8mgiEDJzKqRdWUzdB54WceDRfjx"&lt;/code&gt;&lt;/p&gt;
        /// &lt;/li&gt;
        /// &lt;/ul&gt;
        /// &lt;p&gt;
        /// &lt;strong&gt;Note&lt;/strong&gt;: The second output format can be
        /// ambigious in cases where the output address appears more than once
        /// in the outputs of a single transaction. If this occurs the first
        /// matching output is selected.&lt;/p&gt;
        /// &lt;p&gt;
        /// &lt;strong&gt;Note&lt;/strong&gt;: Importing a user with sent or
        /// received outputs with less than 5 confirmations will
        /// fail.&lt;/p&gt;
        /// &lt;p&gt;
        /// &lt;strong&gt;Note&lt;/strong&gt;: Subsequent import calls with the
        /// same userId are incremental, meaning that you can import another
        /// (E.g. new) version of a user on top of what is registered for that
        /// user already.In other words, any existing outputs or addresses
        /// which are not in the new import will NOT get deleted.&lt;/p&gt;
        /// &lt;p&gt;
        /// &lt;strong&gt;Note&lt;/strong&gt;: If one of the deposit addresses
        /// are associated with a different user the function fails(see
        /// Response Messages below).&lt;/p&gt;
        /// </summary>
        /// <param name='userImport'>
        /// </param>
        /// <param name='token'>
        /// API-key
        /// </param>
        Task<string> UserImportPostWithHttpMessagesAsync(UserImportModel userImport, string token);

        /// <summary>
        /// &lt;p&gt;Get information about a user.&lt;/p&gt;
        /// &lt;p&gt;The follwing information is returned:&lt;/p&gt;
        /// &lt;ul&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;
        /// &lt;code&gt;userId&lt;/code&gt;: the ID of the user&lt;/p&gt;
        /// &lt;/li&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;
        /// &lt;code&gt;creationDate&lt;/code&gt;: the POSIX time when the user
        /// was created&lt;/p&gt;
        /// &lt;/li&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;
        /// &lt;code&gt;comment&lt;/code&gt;: an arbitrary string that can be
        /// set using another API function.Only included if set.&lt;/p&gt;
        /// &lt;/li&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;
        /// &lt;code&gt;score&lt;/code&gt;: the risk score of the user. E.g.
        /// &lt;code&gt;red&lt;/code&gt;, &lt;code&gt;amber&lt;/code&gt;,
        /// or&lt;code&gt; green&lt;/code&gt;. Only included if the user has
        /// sent or received value.&lt;/p&gt;
        /// &lt;/li&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;
        /// &lt;code&gt;scoreUpdatedDate&lt;/code&gt;: the last time the risk
        /// score has been updated in POSIX format. Only included if the user
        /// has sent or received value.&lt;/p&gt;
        /// &lt;/li&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;
        /// &lt;code&gt;lastActivity&lt;/code&gt;: the last time the user sent
        /// or received value in POSIX format. Only included if the user has
        /// sent or received value.&lt;/p&gt;
        /// &lt;/li&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;
        /// &lt;code&gt;exposureDetails&lt;/code&gt;: detailed exposure
        /// data.Only included if the user has sent or received
        /// value.&lt;/p&gt;
        /// &lt;ul&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;
        /// &lt;code&gt;category&lt;/code&gt;: exposure category.&lt;/p&gt;
        /// &lt;/li&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;
        /// &lt;code&gt;sentIndirectExposure&lt;/code&gt;: funds sent
        /// indirectly.&lt;/p&gt;
        /// &lt;/li&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;
        /// &lt;code&gt;sentDirectExposure&lt;/code&gt;: funds sent
        /// directly.&lt;/p&gt;
        /// &lt;/li&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;
        /// &lt;code&gt;receivedIndirectExposure&lt;/code&gt;: funds received
        /// indirectly.&lt;/p&gt;
        /// &lt;/li&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;
        /// &lt;code&gt;receivedDirectExposure&lt;/code&gt;: funds received
        /// directly.&lt;/p&gt;
        /// &lt;/li&gt;
        /// &lt;/ul&gt;
        /// &lt;/li&gt;
        /// &lt;/ul&gt;
        /// </summary>
        /// <param name='userId'>
        /// The ID of the user
        /// </param>
        /// <param name='token'>
        /// API-key
        /// </param>
        Task<UserDetailsModel> UserByUserIdGetWithHttpMessagesAsync(string userId, string token);

        /// <summary>
        /// &lt;p&gt;Set the &lt;code&gt;comment&lt;/code&gt; string on a
        /// user.&lt;/p&gt;
        /// &lt;p&gt;This is a convenience function that allows you to set an
        /// arbitrary string for a user.When retrieving a user the string is
        /// returned.&lt;/p&gt;
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
        Task<object> UserByUserIdCommentPostWithHttpMessagesAsync(string userId, CommentModel comment, string token);

        /// <summary>
        /// &lt;p&gt;List withdrawal addresses associated with a
        /// user.&lt;/p&gt;
        /// &lt;ul&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;Each withdrawal address is given a risk&lt;code&gt;
        /// score&lt;/code&gt;. E.g. &lt;code&gt;red&lt;/code&gt;,
        /// &lt;code&gt;amber&lt;/code&gt;, or&lt;code&gt;
        /// green&lt;/code&gt;.&lt;/p&gt;
        /// &lt;/li&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;If a withdrawal address belongs to a known service,
        /// then&lt;code&gt; name&lt;/code&gt; and&lt;code&gt;
        /// category&lt;/code&gt; will be included and gives the name and
        /// category of that service. Otherwise&lt;code&gt; name&lt;/code&gt;
        /// and&lt;code&gt; category&lt;/code&gt; will be omitted.&lt;/p&gt;
        /// &lt;/li&gt;
        /// &lt;/ul&gt;
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
        Task<UserWithdrawAddressInfoModel> UserByUserIdAddressesWithdrawalGetWithHttpMessagesAsync(string userId, string token, int? limit = default(int?), int? offset = default(int?));

        /// <summary>
        /// &lt;p&gt;Add a withdrawal address associated with a user.&lt;/p&gt;
        /// &lt;ul&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;The user is automatically created if it does not
        /// exist.&lt;/p&gt;
        /// &lt;/li&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;The function is idempotent: If the withdrawal address is
        /// already associated with the user the function succeeds.&lt;/p&gt;
        /// &lt;/li&gt;
        /// &lt;/ul&gt;
        /// &lt;p&gt;The function returns an analysis of the withdrawal
        /// address:&lt;/p&gt;
        /// &lt;ul&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;A risk &lt;code&gt;score&lt;/code&gt;.E.g.
        /// &lt;code&gt;red&lt;/code&gt;, &lt;code&gt;amber&lt;/code&gt;,
        /// or&lt;code&gt; green&lt;/code&gt;.&lt;/p&gt;
        /// &lt;/li&gt;
        /// &lt;li&gt;
        /// &lt;p&gt;If a withdrawal address belongs to a known service,
        /// then&lt;code&gt; name&lt;/code&gt; and&lt;code&gt;
        /// category&lt;/code&gt; will be included and gives the name and
        /// category of that service. Otherwise&lt;code&gt; name&lt;/code&gt;
        /// and&lt;code&gt; category&lt;/code&gt; will be omitted.&lt;/p&gt;
        /// &lt;/li&gt;
        /// &lt;/ul&gt;
        /// &lt;p&gt;Hint: This function could be called both when a user
        /// pastes in the withdrawal address for the first time, and also
        /// before each subsequent withdrawal.&lt;/p&gt;
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
        Task<WithdrawAddressInfoModel> UserByUserIdAddressesWithdrawalPostWithHttpMessagesAsync(string userId, AddressImportModel withdrawalAddress, string token);

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
        Task<object> UserByUserIdAddressesWithdrawalByAddressDeleteWithHttpMessagesAsync(string userId, string address, string token);
    }
}
