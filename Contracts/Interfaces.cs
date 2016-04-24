using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRecordsManager
    { // CRUD
        string Add(IMedicalRecord record);

        void Update(IMedicalRecord updatedRecord);

        IMedicalRecord Read(string userId);

        IEnumerable<IMedicalRecord> ReadBP(string userId);

        IEnumerable<IMedicalRecord> ReadAll(string userId);

        IEnumerable<IMedicalRecord> ReadAll(string userId, int pageNumber);

    }

    public interface ISharingManager
    {
        void ShareRecord(ISharingDestination destination, IMedicalRecord record);
    }

    public interface INotificationManager
    {
        void Notify(INotificationDestination destination, INotificationMessage message);
    }

    public interface ISharingDestination
    {}

    public interface INotificationDestination
    {}

    public interface INotificationMessage
    {}

    public interface IMedicalRecord
    {
        string UserID { get; }
        string RecordID { get; }
        string Type { get; }
        string Json { get; }
        string Title { get; set; }
        string Description { get; set; }
        string Link { get; set; }
    }
}
