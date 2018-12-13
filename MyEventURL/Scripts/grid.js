<!-- Grid Component
<grid :data="Q3"
                 :columns="QColumns"
                 :filter-key="searchQuery"
                 sortKey="Number of Notes"
                 width="650">
</grid>
-->
<script type="text/x-template" id="grid-template">
    <table class="grid" :width="Width">
        <thead>
            <tr>
                <th v-for="key in columns"
                    v-on:click="sortBy(key.name)"
                    :class="{ active: sortKey == key.name }"
                    :class="key.hide == true ? 'hidden-xs' :''"
                    class="grid">
                    {{ key.name | capitalize }}
                    <span class="arrow" :class="sortOrders[key.name] > 0 ? 'asc' : 'dsc'">
                    </span>
                </th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="entry in filteredData">
                <td v-for="key in columns" class="grid"  :class="key.hide == true ? 'hidden-xs' :''">
                    {{key.name != 'Actions' ? entry[key.name] : ""}}
                    <span v-if="key.name == 'Actions'" v-html="returnActions(entry[key.name])"></span>
                </td>
            </tr>
        </tbody>
    </table>
</script>

<script>
    // register the grid component
    Vue.component('grid', {
        template: '#grid-template',
        props: {
            data: Array,
            columns: Array,
            filterKey: String,
            width: String,
            sort: String,
            edit: String,
            view: String,
            delete: String,
            copy: String,
            add: String
        },
        data: function () {
            var sortOrders = {}
            this.columns.forEach(function (key) {
                sortOrders[key] = -1
            })
            return {
                sortKey: this.sort,
                sortOrders: sortOrders,
                Width: this.width,
            }
        },
        computed: {
            filteredData: function () {
                var sortKey = this.sortKey
                var filterKey = this.filterKey && this.filterKey.toLowerCase()
                var order = this.sortOrders[sortKey] || 1
                var data = this.data
                if (filterKey) {
                    data = data.filter(function (row) {
                        return Object.keys(row).some(function (key) {
                            return String(row[key]).toLowerCase().indexOf(filterKey) > -1
                        })
                    })
                }
                if (sortKey) {
                    data = data.slice().sort(function (a, b) {
                        a = a[sortKey]
                        b = b[sortKey]
                        return (a === b ? 0 : a > b ? 1 : -1) * order
                    })
                }
                return data
            }
        },
        filters: {
            capitalize: function (str) {
                return str.charAt(0).toUpperCase() + str.slice(1)
            }
        },
        methods: {
            returnActions: function (id) {
                var returntext = [];
                if (this.copy != null) returntext.push(this.copy.replace(/{replace}/, id));
                if (this.edit != null) returntext.push(this.edit.replace(/{replace}/, id));
                if (this.view != null) returntext.push(this.view.replace(/{replace}/, id));
                if (this.delete != null) returntext.push(this.delete.replace(/{replace}/, id));
                if (this.add != null) returntext.push(this.add.replace(/{replace}/, id));
                return (returntext.join(" | "));
            },
            sortBy: function (key) {
                this.sortKey = key
                this.sortOrders[key] = this.sortOrders[key] * -1
            }
        }
    })
</script>
