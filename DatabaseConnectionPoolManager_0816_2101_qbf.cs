// 代码生成时间: 2025-08-16 21:01:09
using System;
using System.Collections.Concurrent;
using System.Data;
using System.Data.Common;
using System.Linq;

// DatabaseConnectionPoolManager is a class responsible for managing database connections.
public class DatabaseConnectionPoolManager
{
    private ConcurrentBag<DbConnection> connectionPool;
    private string connectionString;
    private readonly string providerInvariantName;
    private readonly int maxConnections;

    // Constructor with parameters for connection string, provider name, and max connections.
    public DatabaseConnectionPoolManager(string connectionString, string providerInvariantName, int maxConnections)
    {
        this.connectionString = connectionString;
        this.providerInvariantName = providerInvariantName;
        this.maxConnections = maxConnections;
        this.connectionPool = new ConcurrentBag<DbConnection>();
    }

    // Method to open a new connection and add it to the pool.
    public DbConnection GetConnection()
    {
        DbConnection connection = null;
        try
        {
            // Create a new connection.
            connection = DbProviderFactories.GetFactory(providerInvariantName).CreateConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            // Add the new connection to the pool.
            connectionPool.Add(connection);
            return connection;
        }
        catch (Exception ex)
        {
            // Handle exceptions and dispose of the connection if it was created.
            Console.WriteLine($"Failed to open a new connection: {ex.Message}");
            if (connection != null)
            {
                connection.Dispose();
            }
            throw;
        }
    }

    // Method to remove a connection from the pool and dispose of it.
    public void ReleaseConnection(DbConnection connection)
    {
        try
        {
            if (connection == null) throw new ArgumentNullException(nameof(connection));
            // Ensure the connection is closed before disposing.
            connection.Close();
            // Remove and dispose the connection from the pool.
            var toRemove = connectionPool.FirstOrDefault(c => c == connection);
            if (toRemove != null)
            {
                connectionPool.TryTake(out _);
                connection.Dispose();
            }
            else
            {
                throw new InvalidOperationException("This connection was not part of the pool or was already removed.");
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions and log them.
            Console.WriteLine($"Failed to release the connection: {ex.Message}");
            throw;
        }
    }

    // Method to clear the pool and dispose of all connections.
    public void ClearPool()
    {
        foreach (var connection in connectionPool)
        {
            if (connection != null)
            {
                connection.Dispose();
            }
        }
        connectionPool.Clear();
    }

    // Property to get the number of connections in the pool.
    public int PoolSize => connectionPool.Count;
}
