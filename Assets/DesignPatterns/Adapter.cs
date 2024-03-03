/****************************************************
 *              ������ ���� Adapter                 *
 ****************************************************/

/*
 * <����� ����>
 * ȣȯ���� ���� �� ��ü�� ������ �� �ֵ��� �߰� �Ű�ü�� �����ϴ� ����
 * 
 * <����>
 * 1. ȣȯ���� �ʴ� �� ��ü ���̿� ����� �߰� ��ü�� ����
 * 2. ����� ��ü�� �� ��ü ������ ��ȣ�ۿ� ����� ���
 * 
 * <����>
 * 1. ������ �ڵ带 �������� �ʰ� ������ �����ϹǷ� ������� ��Ģ�� �ؼ���
 * 2. Ŭ�������� ��ȣ�ۿ뿡 ���� ���踦 ����͸� ���� �������� ������ �� �����Ƿ� ������������ ��Ģ�� �ؼ���
 * 
 * <������>
 * 1. �������̽��� ���� �������� �����Ƿ� �������̽��� �������� ���� �� �ִ� �������� ���� ����
 */

namespace DesignPattern
{
    public class DollarCustomer
    {
        public Exchanger exchanger;

        public void Buy()
        {
            // ���� ����
            exchanger.Change();
        }
    }

    public class KRWStore
    {
        public Exchanger exchanger;

        public void Sell()
        {
            // ���� �Ǹ�
        }
    }

    public class Exchanger
    {
        public DollarCustomer customer;
        public KRWStore store;

        public void Change()
        {
            store.Sell();
        }
    }
}