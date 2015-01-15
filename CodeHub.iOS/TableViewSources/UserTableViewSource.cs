using ReactiveUI;
using CodeHub.Core.ViewModels.Users;
using CodeHub.iOS.Cells;

namespace CodeHub.iOS.TableViewSources
{
    public class UserTableViewSource : ReactiveTableViewSource<UserItemViewModel>
    {
        public UserTableViewSource(UIKit.UITableView tableView, IReactiveNotifyCollectionChanged<UserItemViewModel> collection) 
            : base(tableView, collection,  UserTableViewCell.Key, 44.0f)
        {
            tableView.RegisterClassForCellReuse(typeof(UserTableViewCell), UserTableViewCell.Key);
        }

        public override void RowSelected(UIKit.UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            base.RowSelected(tableView, indexPath);
            var item = ItemAt(indexPath) as UserItemViewModel;
            if (item != null)
                item.GoToCommand.ExecuteIfCan();
        }
    }
}

