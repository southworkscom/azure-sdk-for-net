// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Batch
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// ApplicationOperations operations.
    /// </summary>
    public partial interface IApplicationOperations
    {
        /// <summary>
        /// Activates the specified application package.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group that contains the Batch account.
        /// </param>
        /// <param name='accountName'>
        /// The name of the Batch account.
        /// </param>
        /// <param name='id'>
        /// The id of the application.
        /// </param>
        /// <param name='version'>
        /// The version of the application to activate.
        /// </param>
        /// <param name='parameters'>
        /// The parameters for the request.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to the request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse> ActivateApplicationPackageWithHttpMessagesAsync(string resourceGroupName, string accountName, string id, string version, ActivateApplicationPackageParameters parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Adds an application to the specified Batch account.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group that contains the Batch account.
        /// </param>
        /// <param name='accountName'>
        /// The name of the Batch account.
        /// </param>
        /// <param name='applicationId'>
        /// The id of the application.
        /// </param>
        /// <param name='parameters'>
        /// The parameters for the request.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to the request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<Application>> AddApplicationWithHttpMessagesAsync(string resourceGroupName, string accountName, string applicationId, AddApplicationParameters parameters = default(AddApplicationParameters), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Deletes an application.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group that contains the Batch account.
        /// </param>
        /// <param name='accountName'>
        /// The name of the Batch account.
        /// </param>
        /// <param name='applicationId'>
        /// The id of the application.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to the request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse> DeleteApplicationWithHttpMessagesAsync(string resourceGroupName, string accountName, string applicationId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets information about the specified application.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group that contains the Batch account.
        /// </param>
        /// <param name='accountName'>
        /// The name of the Batch account.
        /// </param>
        /// <param name='applicationId'>
        /// The id of the application.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to the request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<Application>> GetApplicationWithHttpMessagesAsync(string resourceGroupName, string accountName, string applicationId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Updates settings for the specified application.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group that contains the Batch account.
        /// </param>
        /// <param name='accountName'>
        /// The name of the Batch account.
        /// </param>
        /// <param name='applicationId'>
        /// The id of the application.
        /// </param>
        /// <param name='parameters'>
        /// The parameters for the request.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to the request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse> UpdateApplicationWithHttpMessagesAsync(string resourceGroupName, string accountName, string applicationId, UpdateApplicationParameters parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Creates an application package record.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group that contains the Batch account.
        /// </param>
        /// <param name='accountName'>
        /// The name of the Batch account.
        /// </param>
        /// <param name='applicationId'>
        /// The id of the application.
        /// </param>
        /// <param name='version'>
        /// The version of the application.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to the request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<AddApplicationPackageResult>> AddApplicationPackageWithHttpMessagesAsync(string resourceGroupName, string accountName, string applicationId, string version, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Deletes an application package record and its associated binary
        /// file.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group that contains the Batch account.
        /// </param>
        /// <param name='accountName'>
        /// The name of the Batch account.
        /// </param>
        /// <param name='applicationId'>
        /// The id of the application.
        /// </param>
        /// <param name='version'>
        /// The version of the application to delete.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to the request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse> DeleteApplicationPackageWithHttpMessagesAsync(string resourceGroupName, string accountName, string applicationId, string version, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets information about the specified application package.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group that contains the Batch account.
        /// </param>
        /// <param name='accountName'>
        /// The name of the Batch account.
        /// </param>
        /// <param name='applicationId'>
        /// The id of the application.
        /// </param>
        /// <param name='version'>
        /// The version of the application.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to the request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<GetApplicationPackageResult>> GetApplicationPackageWithHttpMessagesAsync(string resourceGroupName, string accountName, string applicationId, string version, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Lists all of the applications in the specified account.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group that contains the Batch account.
        /// </param>
        /// <param name='accountName'>
        /// The name of the Batch account.
        /// </param>
        /// <param name='maxresults'>
        /// The maximum number of items to return in the response.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to the request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<IPage<Application>>> ListWithHttpMessagesAsync(string resourceGroupName, string accountName, int? maxresults = default(int?), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Lists all of the applications in the specified account.
        /// </summary>
        /// <param name='nextPageLink'>
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to the request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<IPage<Application>>> ListNextWithHttpMessagesAsync(string nextPageLink, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}