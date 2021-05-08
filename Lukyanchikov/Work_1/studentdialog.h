#ifndef STUDENTDIALOG_H
#define STUDENTDIALOG_H

#include <QDialog>
#include <QMessageBox>
namespace Ui {
class StudentDialog;
}

class StudentDialog : public QDialog
{
    Q_OBJECT

public:
    QString fio;
    QString group;
    QString chipher;
    explicit StudentDialog(QWidget *parent = nullptr);
    ~StudentDialog();

private slots:
    void on_addButton_clicked();

private:
    Ui::StudentDialog *ui;
};

#endif // STUDENTDIALOG_H
