@description('Name of the Service Bus namespace')
param serviceBusNamespaceName string

@description('Name of the Queue')
param serviceBusQueueName string

@description('Location for all resources.')
param location string = resourceGroup().location

// The service bus
resource serviceBusNamespace 'Microsoft.ServiceBus/namespaces@2022-01-01-preview' = {
  name: serviceBusNamespaceName
  location: location
  sku: {
    name: 'Standard'
  }
  properties: {}
}

// Service bus Queue
resource serviceBusQueue 'Microsoft.ServiceBus/namespaces/queues@2022-01-01-preview' = {
  parent: serviceBusNamespace
  name: serviceBusQueueName
  properties: {
    lockDuration: 'PT5M'
    maxSizeInMegabytes: 1024
    requiresDuplicateDetection: false
    requiresSession: false
    defaultMessageTimeToLive: 'P10675199DT2H48M5.4775807S'
    deadLetteringOnMessageExpiration: false
    duplicateDetectionHistoryTimeWindow: 'PT10M'
    maxDeliveryCount: 10
    autoDeleteOnIdle: 'P10675199DT2H48M5.4775807S'
    enablePartitioning: false
    enableExpress: false
  }
}

// service bus: topic
resource symbolicname 'Microsoft.ServiceBus/namespaces/topics@2022-10-01-preview' = {
  name: 'string'
  parent: resourceSymbolicName
  properties: {
    autoDeleteOnIdle: 'string'
    defaultMessageTimeToLive: 'string'
    duplicateDetectionHistoryTimeWindow: 'string'
    enableBatchedOperations: bool
    enableExpress: bool
    enablePartitioning: bool
    maxMessageSizeInKilobytes: int
    maxSizeInMegabytes: int
    requiresDuplicateDetection: bool
    status: 'string'
    supportOrdering: bool
  }
}

// service bus: topic -> subscription
resource symbolicname 'Microsoft.ServiceBus/namespaces/topics/subscriptions@2022-10-01-preview' = {
  name: 'string'
  parent: resourceSymbolicName
  properties: {
    autoDeleteOnIdle: 'string'
    clientAffineProperties: {
      clientId: 'string'
      isDurable: bool
      isShared: bool
    }
    deadLetteringOnFilterEvaluationExceptions: bool
    deadLetteringOnMessageExpiration: bool
    defaultMessageTimeToLive: 'string'
    duplicateDetectionHistoryTimeWindow: 'string'
    enableBatchedOperations: bool
    forwardDeadLetteredMessagesTo: 'string'
    forwardTo: 'string'
    isClientAffine: bool
    lockDuration: 'string'
    maxDeliveryCount: int
    requiresSession: bool
    status: 'string'
  }
}

// service bus: topic -> subscription -> rule
resource symbolicname 'Microsoft.ServiceBus/namespaces/topics/subscriptions/rules@2022-10-01-preview' = {
  name: 'string'
  parent: resourceSymbolicName
  properties: {
    action: {
      compatibilityLevel: int
      requiresPreprocessing: bool
      sqlExpression: 'string'
    }
    correlationFilter: {
      contentType: 'string'
      correlationId: 'string'
      label: 'string'
      messageId: 'string'
      properties: {}
      replyTo: 'string'
      replyToSessionId: 'string'
      requiresPreprocessing: bool
      sessionId: 'string'
      to: 'string'
    }
    filterType: 'string'
    sqlFilter: {
      compatibilityLevel: int
      requiresPreprocessing: bool
      sqlExpression: 'string'
    }
  }
}