

export default function DashboardPage() {
    return (
        <>
            <div className="flex mb-3">
                <div className="bg-primary-light w-[60px] h-[60px] rounded-full">
                    <img src="" alt="" />
                </div>
            </div>
            <div className="bg-primary-light w-full h-[2px] rounded-[4px]" />
            <div className="py-3 px-5">
                <h1 className="text-3xl font-bold text-gray-700 mb-1">OVERVIEW</h1>
                <div className="bg-primary-light w-[155px] h-[3px] rounded-[4px] mb-5" />
                <div className="flex items-center justify-start flex-wrap gap-x-4 mb-4">
                    <div className="rounded-md bg-gray-300 p-3">
                        <h3>Customer</h3>
                    </div>
                    <div className="rounded-md bg-gray-300 p-3">
                        <h3>Order</h3>
                    </div>
                    <div className="rounded-md bg-gray-300 p-3">
                        <h3>Revenue</h3>
                    </div>
                </div>
                <div className="flex items-center gap-x-4">
                    <div></div>
                    <div></div>
                </div>
            </div>
        </>
    )
}
